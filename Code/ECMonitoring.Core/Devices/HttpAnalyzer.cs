using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;

namespace ECMonitoring.Core.Devices
{
    internal class HttpAnalyzer
    {
        //public delegate void HttpArrivalHandler(CaptureEventArgs e);
        //public event HttpArrivalHandler HttpArrivalOn;

        public void Dispose()
        {
            //
        }

        //internal void Analyze(CaptureEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
        internal bool Analyze(LanDeviceEventArgs e, out LanDeviceHttpStatus httpStatus)
        {
            throw new NotImplementedException();
        }


    }
}
