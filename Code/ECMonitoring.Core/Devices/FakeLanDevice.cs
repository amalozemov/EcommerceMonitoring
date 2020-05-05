﻿using ECMonitoring.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    internal class FakeLanDevice : ILanDevice
    {
        public event PacketArrivalHandler PacketArrivalOn;

        public string Ip { get; private set; }
        public int Port { get; private set; }

        Timer _timer;

        public FakeLanDevice(string ip, int port)
        {
            Ip = ip;
            Port = port;
            
        }

        private void TimerOn(object state)
        {
            #region httpHeader

            var httpHeader = @"HTTP/1.1 200 OK
Cache - Control: private
Content-Length: 117
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/7.5
X-AspNet-Version: 4.0.30319
X-Powered-By: ASP.NET
Access-Control-Allow-Origin: *
Date: Mon, 04 May 2020 11:24:57 GMT" +
"{\"d\":{\"__type\":\"ActionServiceRequestResult:#GMCS.MTT.XRM.Domain.DTO.Action\",\"ActionCode\":\"1\",\"ActionMessage\":\"1234\"}}\"";

            #endregion

            var proto =
                httpHeader.IndexOf("http", StringComparison.CurrentCultureIgnoreCase) >= 0 || httpHeader.IndexOf("post", StringComparison.CurrentCultureIgnoreCase) >= 0 ? "HTTP" : "TCP";

            var srcIp = "192.168.0.103";
            var dstIp = "192.168.0.100";
            var rst = false;
            var isHttpPresent = GetIsHttpPresent();
            var httpAttributes = default(HttpHeaderAttributes);

            if (isHttpPresent)
            {
                httpAttributes = new HttpHeaderAttributes(srcIp, httpHeader);
            }

            var eventArgs =
                new LanDeviceEventArgs(srcIp, dstIp, rst, isHttpPresent, httpAttributes);

            PacketArrivalOn?.BeginInvoke(this, eventArgs, null, null);
        }

        private int _tickCount;
        private bool GetIsHttpPresent()
        {
            if (_tickCount == 2)
            {
                _tickCount = 0;
                return true;
            }
            _tickCount++;
            return false;
        }

        public void Start()
        {
            if (_timer != null)
            {
                throw new DeviceAlreadyConnectedException("Устройство уже подключено.");
            }

            _timer = new Timer(TimerOn,null, 0, 1000);

            //_timer.Change(0, 1000);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
        }
    }
}
