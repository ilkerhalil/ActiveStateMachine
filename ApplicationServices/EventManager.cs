using System;
using System.Collections.Generic;
using System.ComponentModel;
using ActiveStateMachine;

namespace ApplicationServices
{
    public class EventManager
    {
        private Dictionary<string, object> Eventlist;

        public event EventHandler<StateMachineEventArgs> EventManagerEvent;

        private static readonly Lazy<EventManager> _eventManager = new Lazy<EventManager>(() => new EventManager());

        public static EventManager Instance
        {
            get { return _eventManager.Value; }
        }

        public EventManager()
        {
            Eventlist = new Dictionary<string, object>();
        }


        public void RegisterEvent(string eventName, object source)
        {
            Eventlist.Add(eventName, source);
        }

        public bool SubscribeEvent(string eventName, string handlerMethodName, object sink)
        {
            try
            {
                var evt = Eventlist[eventName];
                var eventInfo = evt.GetType().GetEvent(eventName);
                var methodInfo = sink.GetType().GetMethod(handlerMethodName);
                var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, sink, methodInfo);
                eventInfo.AddEventHandler(evt, handler);
                return true;
            }
            catch (Exception exception)
            {
                var message = $"Exception while subscribing to handler. Event {eventName} - Handler - {handlerMethodName} - Exception - {exception}";
                RaiseEventManagerEvent("EventManagerSystemEvent",message,StateMachineEventType.System);
                throw;
            }
        }

        private void RaiseEventManagerEvent(string eventName, string eventInfo, StateMachineEventType eventType)
        {
            var newArgs = new StateMachineEventArgs(eventName, eventInfo, eventType, "Event Manager");
            EventManagerEvent?.Invoke(this, newArgs);
        }

    }
}
