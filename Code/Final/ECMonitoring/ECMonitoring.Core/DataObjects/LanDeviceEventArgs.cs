using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class LanDeviceEventArgs : EventArgs
    {
        public string SrcIp { get; private set; }
        public string DstIp { get; private set; }
        public bool IsHttpPresent { get; private set; }
        public bool IsRst { get; private set; }
        public HttpHeaderAttributes HttpContent { get; private set; }

        public LanDeviceEventArgs(string srcIp, string dstIp, bool isRst, bool isHttpPresent, HttpHeaderAttributes httpContent)
        {
            SrcIp = srcIp;
            DstIp = dstIp;
            IsHttpPresent = isHttpPresent;
            IsRst = isRst;
            HttpContent = httpContent;
        }
    }
}
