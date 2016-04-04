using System;
using System.Linq;
using Common;

namespace ApplicationServices
{
    public class ViewManager
    {
        string[] _viewStates;
        string DefaultViewState;

        private IUserInterface _UI;

        public event EventHandler<StateMachineEventArgs> ViewManagerEvent;

        public string CurrentView { get; set; }

        public IViewStateConfiguration ViewStateConfiguration { get; set; }


        private static readonly Lazy<ViewManager> _viewManager = new Lazy<ViewManager>(() => new ViewManager());

        public static ViewManager Instance
        {
            get { return _viewManager.Value; }
        }


        private ViewManager()
        {
        }

        public void LoadViewStateConfiguration(IViewStateConfiguration viewStateConfiguration,
            IUserInterface userInterface)
        {
            ViewStateConfiguration = viewStateConfiguration;
            _viewStates = viewStateConfiguration.ViewStateList;
            _UI = userInterface;
            DefaultViewState = viewStateConfiguration.DefaultViewState;
        }

        public void ViewCommandHandler(object sender, StateMachineEventArgs args)
        {
            try
            {
                if (_viewStates.Contains(args.EventName))
                {
                    _UI.LoadViewState(args.EventName);
                    CurrentView = args.EventName;
                    RaiseEventManagerEvent("View Manager Command", $"Successfully loaded view state: {args.EventName}");
                }
                else
                {
                    RaiseEventManagerEvent("View Manager Command", "View state not found");
                }
            }
            catch (Exception exception)
            {
                RaiseEventManagerEvent("View Manager Command - Error", exception.ToString());
            }
        }

        public void SystemEventHandler(object sender, StateMachineEventArgs args)
        {
            if (args.EventName != "OnInit") return;
            _UI.LoadViewState(DefaultViewState);
            CurrentView = DefaultViewState;
        }

        public void RaiseEventManagerEvent(string name, string info, StateMachineEventType eventType = StateMachineEventType.System)
        {
            var newArgs = new StateMachineEventArgs(name, $"View manager event: {info}", eventType, "View Manager");
            ViewManagerEvent?.Invoke(this, newArgs);
        }

        public void RaiseUICommand(string command, string info, string source, string target)
        {
            var newUIargs = new StateMachineEventArgs(command, info, StateMachineEventType.Command, source, target);
            ViewManagerEvent?.Invoke(this, newUIargs);
        }

    }
}
