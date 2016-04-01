using System;

namespace ActiveStateMachine
{
    public class StateMachineAction
    {

        public string Name { get; private set; }

        private Action _method;

        public StateMachineAction(string name, Action method)
        {
            _method = method;
            Name = name;
        }

        public void Execute()
        {
            _method.Invoke();
        }
    }
}
