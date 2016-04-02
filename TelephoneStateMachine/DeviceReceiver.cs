using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices;

namespace TelephoneStateMachine
{
    public class DeviceReceiver:Device
    {
        public bool ReceiverLifted { get; set; }


        public DeviceReceiver(string deviceName, Action<string, string, string> eventCallBack) 
            : base(deviceName, eventCallBack)
        {
        }

        public override void OnInit()
        {
            ReceiverLifted = false;
        }

        public void OnReceiverUp()
        {
            ReceiverLifted = true;
            DoNotificationCallBack("OnReceiverUp","Receiver lifted","Receiver");
        }
        public void OnReceiverDown()
        {
            ReceiverLifted = false;
            DoNotificationCallBack("OnReceiverDown", "Receiver down", "Receiver");
        }

    }
}
