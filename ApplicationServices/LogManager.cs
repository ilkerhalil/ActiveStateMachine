using System;
using System.Diagnostics;
using Common;

namespace ApplicationServices
{
    public class LogManager
    {
        private static readonly Lazy<LogManager> Logger = new Lazy<LogManager>(() => new LogManager());
        public static LogManager Instance => Logger.Value;

        private LogManager() { }


        public void LogEventHandler(object sender, StateMachineEventArgs args)
        {
            Debug.Print(args.EventType != StateMachineEventType.Notification
                ? $"{args.TimeStamp} SystemEvent: {args.EventName} - Info: {args.EventInfo} - StateMachineArgumentType:{args.EventType} - Source {args.Source} - Target :{args.Target}"
                : $"{args.TimeStamp} Notification: {args.EventName} - Info: {args.EventInfo} - StateMachineArgumentType:{args.EventType} - Source {args.Source} - Target :{args.Target}");
        }
    }
}