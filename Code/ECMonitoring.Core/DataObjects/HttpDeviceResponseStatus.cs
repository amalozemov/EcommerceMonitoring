﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Core
{
    public class HttpDeviceResponseStatus
    {
        public string MethodServiceSignature { get; private set; }
        public string ErrorDescription { get; private set; }
        public string ErrorCode { get; private set; }
        public ServerHttpResponseStatus ResponseStatus { get; private set; }
        public string SrcIp { get; private set; }

        public HttpDeviceResponseStatus()
        {
            ResponseStatus = ServerHttpResponseStatus.OK;
        }

        public HttpDeviceResponseStatus(string srcIp, ServerHttpResponseStatus responseStatus, string methodServiceSignature, string errorDescription, string errorCode)
        {
            MethodServiceSignature = methodServiceSignature;
            ErrorDescription = ErrorDescription;
            ErrorCode = errorCode;
            ResponseStatus = responseStatus;
            SrcIp = srcIp;
        }
    }
}
