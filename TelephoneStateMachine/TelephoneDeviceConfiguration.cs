using System.Collections.Generic;
using ApplicationServices;
using Common;

namespace TelephoneStateMachine
{
    public class TelephoneDeviceConfiguration : IDeviceConfiguration
    {
        private readonly DeviceManager _deviceManager;

        public Dictionary<string, object> Devices { get; set; }

        public TelephoneDeviceConfiguration()
        {
            _deviceManager = DeviceManager.Instance;
            InitDevices();
        }

        private void InitDevices()
        {
            var bell = new DeviceBell("Bell", _deviceManager.RaiseDeviceManagerNotification);
            var phoneLine = new DevicePhoneLine("PhoneLine", _deviceManager.RaiseDeviceManagerNotification);
            var receiver = new DeviceReceiver("Receiver", _deviceManager.RaiseDeviceManagerNotification);

            Devices = new Dictionary<string, object>
            {
                { "Bell", bell },
                { "PhoneLine", phoneLine },
                { "Receiver", receiver }
            };
        }
    }
}
