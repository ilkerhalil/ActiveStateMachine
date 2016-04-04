using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace ActiveStateMachine
{
    public class ActiveStateMachine
    {
        public Dictionary<string, State> StateList { get; private set; }

        public BlockingCollection<string> TriggerQueue { get; private set; }

        public State CurrentState { get; private set; }

        public State PreviousState { get; private set; }

        public EngineState StateMachineEngine { get; private set; }

        public event EventHandler<StateMachineEventArgs> StateMachineEvents;

        private Task _queneWorkerTask;
        private readonly State _initialState;
        private ManualResetEvent _resumer;
        private CancellationTokenSource _tokenSource;

        public ActiveStateMachine(Dictionary<string, State> stateList, int queueCapacity)
        {
            StateList = stateList;
            _initialState = new State("InitialState", null, null, null);
            TriggerQueue = new BlockingCollection<string>(queueCapacity);
            InitStateMachine();

            RaiseStateMachineSystemEvent("StateMachine: Initialize", "System ready to start");
            StateMachineEngine = EngineState.Initialized;

        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            _queneWorkerTask = Task.Factory.StartNew(QueueWorkerMethod, _tokenSource, TaskCreationOptions.LongRunning);
            StateMachineEngine = EngineState.Running;
            RaiseStateMachineSystemEvent("State Machine: Started", "System running");
        }

        private void QueueWorkerMethod(object obj)
        {
            _resumer.WaitOne();

            try
            {
                foreach (var trigger in TriggerQueue.GetConsumingEnumerable())
                {
                    if (_tokenSource.IsCancellationRequested)
                    {
                        RaiseStateMachineSystemEvent("State machine: QueueWorker", "Processing canceled!");
                        return;
                    }
                    foreach (var transition in CurrentState.StateTansitionList.Where(transition => trigger == transition.Value.Trigger))
                    {
                        ExecuteTransition(transition.Value);
                    }
                }
            }
            catch (Exception exception)
            {

                RaiseStateMachineSystemEvent("State machine: QueueWorker",
                    $"Processing canceled! Exception: {exception.Message}");
                Start();
            }
        }

        private void ExecuteTransition(Transition transition)
        {
            if (CurrentState.StateName == transition.SourceStateName)
            {
                var message =
                    $"Transition has wrong source state {transition.SourceStateName}, when system is in {CurrentState.StateName}";
                RaiseStateMachineSystemEvent("State machine: Default guard execute transition", message);
                return;
            }
            if (!StateList.ContainsKey(transition.TargetStateName))
            {
                var message =
                   $"Transition has wrong source state {transition.SourceStateName}, when system is in {CurrentState.StateName}";
                RaiseStateMachineSystemEvent("State machine: Default guard execute transition", message);
                return;
            }
            CurrentState.ExitActions.ForEach(a => a.Execute());

            transition.GuardList.ForEach(g => g.Execute());

            var info = $"{transition.GuardList.Count} guard actions executed";
            RaiseStateMachineSystemEvent("State machine: ExecuteTransition", info);

            transition.TransitionActionList.ForEach(t => t.Execute());

            info = $"{transition.TransitionActionList.Count} transition actions executed!";
            RaiseStateMachineSystemEvent("State machine: Begin state change!", info);

            var targetState = GetStateFromStateList(transition.TargetStateName);

            PreviousState = CurrentState;
            CurrentState = targetState;

            foreach (var stateMachineAction in CurrentState.EntryActions)
            {
                stateMachineAction.Execute();
            }
            RaiseStateMachineSystemEvent("State machine: State change completed successfully!", $"Previous state: {PreviousState.StateName} - New State- {CurrentState.StateName}");

        }

        private State GetStateFromStateList(string targetStateName)
        {
            return StateList[targetStateName];
        }

        public void Pause()
        {
            StateMachineEngine = EngineState.Paused;
            _resumer.Reset();
            RaiseStateMachineSystemEvent("State Machine: Paused", "System waiting");
        }

        public void Resume()
        {
            _resumer.Set();
            StateMachineEngine = EngineState.Running;
            RaiseStateMachineSystemEvent("StateMachine: Resumed", "System running");
        }

        public void Stop()
        {
            _tokenSource.Cancel();
            _queneWorkerTask.Wait();
            _queneWorkerTask.Dispose();
            StateMachineEngine = EngineState.Stopped;
            RaiseStateMachineSystemEvent("StateMachine: Stopped", "System execution stopped.");

        }

        private void EnterTrigger(string newTrigger)
        {
            try
            {
                TriggerQueue.Add(newTrigger);
            }
            catch (Exception exception)
            {
                RaiseStateMachineSystemEvent("ActiveStateMachine - Error entering trigger", $"{newTrigger} - {exception}");
            }
            RaiseStateMachineSystemEvent("ActiveStateMachine - Trigger entered", newTrigger);
        }

        private void RaiseStateMachineSystemEvent(string eventName, string eventInfo)
        {
            StateMachineEvents?.Invoke(this, new StateMachineEventArgs(eventName, eventInfo, StateMachineEventType.System, "State machine"));
        }

        public void InitStateMachine()
        {
            PreviousState = _initialState;
            foreach (var state in StateList)
            {
                if (!state.Value.IsDefaultState) continue;
                CurrentState = state.Value;
                RaiseStateMachineSystemCommand("OnInit", "StateMachineInitialized");
            }
            _resumer = new ManualResetEvent(true);
        }

        private void RaiseStateMachineSystemCommand(string eventName, string eventInfo)
        {
            StateMachineEvents?.Invoke(this, new StateMachineEventArgs(eventName, eventInfo, StateMachineEventType.Command, "State machine"));
        }

        public void InternalNotificationHandler(object sender, StateMachineEventArgs intArgs)
        {
            EnterTrigger(intArgs.EventName);
        }
    }
}
