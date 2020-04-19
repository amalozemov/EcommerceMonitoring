using SharpPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    // Сетевая карта

    public class LanDevice
    {
        public delegate void PacketArrivalHandler(CaptureEventArgs e);
        public event PacketArrivalHandler PacketArrivalOn;
        public string Ip { get; private set; }
        public int Port { get; private set; }

        public LanDevice(string ip, int port)
        {
            Ip = ip;
            Port = port;
        }

        public void Start()
        {

        }

        public void Stop()
        {

        }
    }
}
