namespace TelephoneStateMachine
{
    public class TelephoneStateMachine : ActiveStateMachine.ActiveStateMachine
    {
        private TelephoneStateMachineConfiguration _config;

        public TelephoneStateMachine(TelephoneStateMachineConfiguration config)
             : base(config.TelephoneStateMachineStateList, config.MaxEntries)
        {
            _config = config;
            config.DoEventMappings(this, _config.TelephoneActivities);
        }
    }
}
