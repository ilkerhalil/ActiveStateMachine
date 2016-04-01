using System.Collections.Generic;

namespace ActiveStateMachine
{
    public class State
    {
        public string StateName { get; private set; }

        public Dictionary<string, Transition> StateTansitionList { get; private set; }

        public List<StateMachineAction> EntryActions { get; private set; }

        public List<StateMachineAction> ExitActions { get; private set; }

        public bool IsDefaultState { get; private set; }


        public State(string stateName, Dictionary<string, Transition> stateTansitionList, List<StateMachineAction> entryActions, List<StateMachineAction> exitActions)
        {
            StateName = stateName;
            StateTansitionList = stateTansitionList;
            EntryActions = entryActions;
            ExitActions = exitActions;
        }

    }

}