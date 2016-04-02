using System;
using ApplicationServices;

namespace TelephoneStateMachine
{
    public class DeviceBell : Device
    {
        public bool Ringing { get; set; }

        public DeviceBell(string deviceName, Action<string, string, string> eventCallBack) : base(deviceName, eventCallBack) { }

        public override void OnInit()
        {
            Ringing = false;
        }

        public void Rings()
        {
            Ringing = true;
            System.Media.SystemSounds.Hand.Play();
        }

        public void Silent()
        {
            Ringing = false;
        }
    }
}
