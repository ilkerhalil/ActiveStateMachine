using System;
using ActiveStateMachine;
using Common;

namespace TelephoneStateMachine
{
    public class TelephoneActivities
    {
        public event EventHandler<StateMachineEventArgs> TelephoneUiEvent;
        public event EventHandler<StateMachineEventArgs> TelephoneDeviceEvent;

        public void ActionBellRings()
        {
            RaiseDeviceEvent("Bell", "Rings");
        }
        public void ActionBellSilent()
        {
            RaiseDeviceEvent("Bell", "Silent");
        }
        public void ActionLineOff()
        {
            RaiseDeviceEvent("PhoneLine", "OffInternal");
        }

        public void ActionLineActive()
        {
            RaiseDeviceEvent("PhoneLine", "ActiveInternal");
        }

        public void ActionViewPhoneRings()
        {
            RaiseTelephoneUiEvent("ViewPhoneRings");
        }
        public void ActionViewPhoneIdle()
        {
            RaiseTelephoneUiEvent("ViewPhoneIdle");
            System.Media.SystemSounds.Beep.Play();
        }
        public void ActionViewTalking()
        {
            RaiseTelephoneUiEvent("ViewTalking");
        }

        public void ActionErrorPhoneRings()
        {
            RaiseTelephoneUiEvent("ViewErrorPhoneRings");
        }



        public void RaiseTelephoneUiEvent(string command)
        {
            var telArgs = new StateMachineEventArgs(command,"UI Command",StateMachineEventType.Command,"State machine action","View Manager");
            TelephoneUiEvent?.Invoke(this, telArgs);
        }

        private void RaiseDeviceEvent(string target, string command)
        {
            var telArgs = new StateMachineEventArgs(command, "Device Command", StateMachineEventType.Command, "State machine action", target);
            TelephoneUiEvent?.Invoke(this, telArgs);
        }

        
    }
}
