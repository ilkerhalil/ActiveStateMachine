using System;
using ApplicationServices;

namespace TelephoneStateMachine
{
    public class DevicePhoneLine : Device
    {

        public bool LineActiveExternal { get; set; }

        public bool LineActiveInternal { get; set; }


        public DevicePhoneLine(string deviceName, Action<string, string, string> eventCallBack) : base(deviceName, eventCallBack)
        {
        }

        public void ActiveExternal()
        {
            LineActiveExternal = true;
            DoNotificationCallBack("OnLineExternalActive", "Phone line set to active", DevName);
        }


        public void ActiveInternal()
        {
            LineActiveInternal = true;
        }

        public void OffInternal()
        {
            LineActiveInternal = false;
            System.Media.SystemSounds.Hand.Play();
        }

        public override void OnInit()
        {
            LineActiveExternal = false;
            LineActiveInternal = false;
        }

    }
}