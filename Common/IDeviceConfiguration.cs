using System.Collections.Generic;

namespace Common
{
    public interface IDeviceConfiguration
    {
        Dictionary<string, object> Devices { get; set; }
    }
}