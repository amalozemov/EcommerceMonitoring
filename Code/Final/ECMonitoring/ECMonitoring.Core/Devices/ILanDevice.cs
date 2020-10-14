using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    internal delegate void PacketArrivalHandler(object sender, LanDeviceEventArgs e);
    internal interface ILanDevice
    {
        void Start();
        void Stop();
        event PacketArrivalHandler PacketArrivalOn;
    }
}
