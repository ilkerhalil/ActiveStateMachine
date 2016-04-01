using System;
using System.Diagnostics;
using ActiveStateMachine;

namespace ApplicationServices
{
    public class LogManager
    {
        private static readonly Lazy<LogManager> Logger = new Lazy<LogManager>(() => new LogManager());
        public static LogManager Instance => Logger.Value;

        private LogManager() { }


        public void LogEventHandler(object sender, StateMachineEventArgs args)
        {
            if (args.EventType != StateMachineEventType.Notification)
            {
                Debug.Print($"{args.TimeStamp} SystemEvent: {args.EventName} - Info: {args.EventInfo} - StateMachineArgumentType:{args.EventType} - Source {args.Source} - Target :{args.Target}");
            }
            else
            {
                Debug.Print($"{args.TimeStamp} Notification: {args.EventName} - Info: {args.EventInfo} - StateMachineArgumentType:{args.EventType} - Source {args.Source} - Target :{args.Target}");

            }
        }

    }
}