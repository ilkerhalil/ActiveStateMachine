using System;
using System.Collections.Generic;
using System.Linq;
using ActiveStateMachine;
using Common;

namespace ApplicationServices
{
    public class DeviceManager
    {
        static readonly Lazy<DeviceManager> _deviceManager = new Lazy<DeviceManager>(() => new DeviceManager());

        public static DeviceManager Instance { get { return _deviceManager.Value; } }


        private DeviceManager()
        {
            DeviceList = new Dictionary<string, object>();
        }

        public Dictionary<string, object> DeviceList { get; set; }

        public event EventHandler<StateMachineEventArgs> DeviceManagerEvent;
        public event EventHandler<StateMachineEventArgs> DeviceManagerNotification;

        public void AddDevice(string deviceName, object device)
        {
            DeviceList.Add(deviceName, device);
            RaiseDeviceManagerEvent("Added device", deviceName);
        }

        public void RemoveDevice(string deviceName)
        {
            DeviceList.Remove(deviceName);
            RaiseDeviceManagerEvent("Remove device", deviceName);
        }

        public void SystemEventHandler(object sender, StateMachineEventArgs args)
        {
            if (args.EventName == "OnInit" && args.EventType == StateMachineEventType.Command)
            {
                foreach (var dev in DeviceList)
                {
                    try
                    {
                        var initMethod = dev.Value.GetType().GetMethod("OnInit");
                        initMethod.Invoke(dev.Value, new object[] {});
                        RaiseDeviceManagerEvent("Device Command - Initialization device",dev.Key);
                    }
                    catch (Exception exception)
                    {
                        RaiseDeviceManagerEvent($"Device command - Initialization error device {dev.Key}",exception.ToString());
                    }
                }
            }
            if (args.EventType == StateMachineEventType.Command)
            {
                if(args.EventName =="OnInit")return;
                if(!DeviceList.ContainsKey(args.Target))return;
                DeviceCommandHandler(this, args);
            }
        }

        public void DeviceCommandHandler(object sender, StateMachineEventArgs args)
        {
            if(args.EventType == StateMachineEventType.Command)return;
            try
            {
                if(!DeviceList.Keys.Contains(args.Target))return;
                var device = DeviceList[args.Target];
                var deviceMethod = device.GetType().GetMethod(args.EventName);
                deviceMethod.Invoke(device, new object[] {});
                RaiseDeviceManagerEvent("DeviceCommand",$"Successful device command {args.Target} - {args.EventName}");
            }
            catch (Exception exception)
            {
                RaiseDeviceManagerEvent("DeviceCommand -Error",exception.ToString());
            }
        }


        private void RaiseDeviceManagerEvent(string name, string info)
        {
            var newDMargs = new StateMachineEventArgs(name, $"Device manager {info}", StateMachineEventType.System, "Device Manager");
            DeviceManagerEvent?.Invoke(this, newDMargs);
        }

        public void RaiseDeviceManagerNotification(string command, string info, string source)
        {
            var newDMargs = new StateMachineEventArgs(command, info, StateMachineEventType.Notification, source, "State ");
            var tempHandler = DeviceManagerNotification;
            DeviceManagerNotification?.Invoke(this, newDMargs);
        }


        public void LoadDeviceConfiguration(IDeviceConfiguration devManConfiguration)
        {
            DeviceList = devManConfiguration.Devices;
        }
    }
}