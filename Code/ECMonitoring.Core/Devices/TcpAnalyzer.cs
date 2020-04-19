using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;

namespace ECMonitoring.Core.Devices
{
    public class TcpAnalyzer
    {
        public delegate void TcpArrivalHandler(CaptureEventArgs e);
        public event TcpArrivalHandler TcpArrivalOn;

        public void Analyze(CaptureEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
