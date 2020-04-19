using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;

namespace ECMonitoring.Core.Devices
{
    public class HttpAnalyzer
    {
        public delegate void HttpArrivalHandler(CaptureEventArgs e);
        public event HttpArrivalHandler HttpArrivalOn;

        internal void Analyze(CaptureEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
