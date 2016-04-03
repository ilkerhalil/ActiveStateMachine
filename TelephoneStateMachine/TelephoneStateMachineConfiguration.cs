using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using ActiveStateMachine;
using ApplicationServices;

namespace TelephoneStateMachine
{
    public class TelephoneStateMachineConfiguration
    {
        public Dictionary<string,State> TelephoneStateMachineStateList { get; set; }

        public TelephoneActivities TelephoneActivities { get; set; }

        public int MaxEntries { get; } = 50;

        public EventManager TelephoneEventManager;

        public ViewManager TelephoneViewManager;

        public DeviceManager TelephoneDeviceManager;

        public LogManager TelephoneLogManager;

        public TelephoneStateMachineConfiguration()
        {
            BuildConfig();
        }

        private void BuildConfig()
        {
            TelephoneActivities = new TelephoneActivities();

            var actionBellRings = new StateMachineAction("ActionBellRings",TelephoneActivities.ActionBellRings);
            var actionBellSlient = new StateMachineAction("ActionBellSlient", TelephoneActivities.ActionBellSilent);
            var actionLineOff = new StateMachineAction("ActionLineOff", TelephoneActivities.ActionLineOff);
            var actionLineActive = new StateMachineAction("ActionLineActive", TelephoneActivities.ActionLineActive);


            var actionViewPhoneRings = new StateMachineAction("ActionViewPhoneRings",TelephoneActivities.ActionViewPhoneRings);
            var actionViewPhoneIdle = new StateMachineAction("ActionViewPhoneIdle", TelephoneActivities.ActionViewPhoneIdle);

            var actionViewTalking= new StateMachineAction("ActionViewTalking", TelephoneActivities.ActionViewTalking);

            var emptyList= new List<StateMachineAction>();
            var ICActions = new List<StateMachineAction> {actionViewPhoneRings};

            var transIncomingCall = new Transition("TransitionIncomingCall","StatePhoneIdle","StatePhoneRings",emptyList,ICActions,"OnLineExternalActive");
            
            var CBActions = new List<StateMachineAction>() {actionViewPhoneIdle};
            var transcallBlocked = new Transition("TransitionCallBlocked","StatePhoneRings","StatePhoneIdle",emptyList,CBActions,"OnRecevierDown");

            var CAActions = new List<StateMachineAction> {actionViewTalking};
            var transCallAccepted = new Transition
                ("TransitionCallAccepted","StatePhoneRings","StateTalking",emptyList,CAActions,"OnReceiverUp");

            var CEActions = new List<StateMachineAction>() {actionViewPhoneIdle};
            var transCallEnded = new Transition("TransitionCallEnded","StateTalking","StatePhoneIdle",emptyList,CEActions,"OnReceiverDown");


            var transitionPhoneIdle = new Dictionary<string, Transition>();
            var entryActionPhoneIdle = new List<StateMachineAction>();

            var exitActionPhoneIdle= new List<StateMachineAction>();
            transitionPhoneIdle.Add("TransitionIncomingCall",transIncomingCall);

            var phoneIdle= new State("StatePhoneIdle",transitionPhoneIdle,entryActionPhoneIdle,exitActionPhoneIdle,true);

            var transitionsPhoneRings = new Dictionary<string,Transition>();
            var entryActionsPhoneRings = new List<StateMachineAction>() {actionBellRings};
            var exitActionsPhoneRings = new List<StateMachineAction>() {actionBellSlient};
            transitionsPhoneRings.Add("TransitionCallBlocked",transcallBlocked);
            transitionsPhoneRings.Add("TransitionCallAccepted", transCallAccepted);
            var phoneRings = new State("StatePhoneRings",transitionsPhoneRings,entryActionsPhoneRings,exitActionsPhoneRings);

            var transitionActionsTalking = new Dictionary<string,Transition>();
            var entryActionsTalking = new List<StateMachineAction>() {actionLineActive};
            var exitActionsTalking = new List<StateMachineAction>() {actionLineOff};
            transitionActionsTalking.Add("TransitionCallEnded",transCallEnded);

            var talking = new State("StateTalking",transitionActionsTalking,entryActionsTalking,exitActionsTalking);




        }
    }
}