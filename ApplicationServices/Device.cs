using System;
using System.Reflection;

namespace ApplicationServices
{
    public abstract class Device
    {
        Action<string, string, string> _devEvMethod;

        public string DevName { get; set; }


        public Device(string deviceName, Action<string, string, string> eventCallBack)
        {
            DevName = deviceName;
            _devEvMethod = eventCallBack;
        }

        public abstract void OnInit();

        public void RegisterEventCallBack(Action<string, string, string> method)
        {
            _devEvMethod = method;
        }

        public void DoNotificationCallBack(string name, string eventInfo, string source)
        {
            _devEvMethod.Invoke(name, eventInfo, source);
        }


    }
}
