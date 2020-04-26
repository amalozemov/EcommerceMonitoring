using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    internal class HttpHeaderAttributes
    {
        //public ServerHttpResponseStatus ResponseStatus { get; private set; }
        public string SrcIp { get; private set; }
        //public string ErrorDescription { get; private set; }
        public string HttpHeader { get; private set; }


        public HttpHeaderAttributes(string srcIp, string httpHeader)
        {
            HttpHeader = httpHeader;
            SrcIp = srcIp;
        }

        //public HttpAttributes(ServerHttpResponseStatus responseStatus, string srcIp, string errorDescription) : this(responseStatus, srcIp)
        //{
        //    ErrorDescription = errorDescription;
        //}
    }
}
