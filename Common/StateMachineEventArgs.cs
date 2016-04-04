using System;

namespace Common
{
    public class StateMachineEventArgs
    {
        public string EventName { get; set; }


        public string EventInfo { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }

        public StateMachineEventType EventType { get; set; }

        // Constructor
        public StateMachineEventArgs(string eventName, string eventInfo, StateMachineEventType eventType, string source, string target = "All")
        {
            EventName = eventName;
            EventInfo = eventInfo;
            EventType = eventType;
            Source = source;
            Target = target;
            TimeStamp = DateTime.Now; // Time stamp automatically added, when args are created. Does not need to be provided.
        }

    }
}
