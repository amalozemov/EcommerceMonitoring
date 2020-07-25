using ECMonitoring.Core.Exceptions;
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

        int _rstCount;
        private void TimerOn(object state)
        {
            //Console.WriteLine("Сработал таймер........................................");

            //var proto =
            //    httpHeader.IndexOf("http", StringComparison.CurrentCultureIgnoreCase) >= 0 || httpHeader.IndexOf("post", StringComparison.CurrentCultureIgnoreCase) >= 0 ? "HTTP" : "TCP";
            //return;

            var srcIp = "192.168.0.103";
            var dstIp = "192.168.0.101";
            var rst = true;
            if (_rstCount == 2)
            {
                rst = false;
                _rstCount = 0;
            }
            else
            {
                _rstCount++;
            }
            var isHttpPresent = IsHttpPresent();
            var httpAttributes = default(HttpHeaderAttributes);

            if (isHttpPresent)
            {
                var httpHeader = GetHttpHeader();
                httpAttributes = new HttpHeaderAttributes(srcIp, httpHeader);
            }

            var eventArgs =
                new LanDeviceEventArgs(srcIp, dstIp, rst, isHttpPresent, httpAttributes);

            PacketArrivalOn?.BeginInvoke(this, eventArgs, null, null);
            //PacketArrivalOn?.Invoke(this, eventArgs);
        }

        int _countHttp;
        private string GetHttpHeader()
        {
            var part1 = @"HTTP/1.1 200 OK ";
            if (_countHttp == 1)
            {
                part1 = @"HTTP/1.1 500 ERROR ";
                _countHttp = 0;
            }
            else
            {
                _countHttp++;
            }
            var httpHeader = part1 + 
@"Cache - Control: private
Content-Length: 117
Content-Type: application/json; charset=utf-8
Server: Microsoft-IIS/7.5
X-AspNet-Version: 4.0.30319
X-Powered-By: ASP.NET
Access-Control-Allow-Origin: *
Date: Mon, 04 May 2020 11:24:57 GMT" +
"{\"d\":{\"__type\":\"ActionServiceRequestResult:#GMCS.MTT.XRM.Domain.DTO.Action\",\"ActionCode\":\"1\",\"ActionMessage\":\"1234\"}}\"";

            return httpHeader;
        }

        private int _tickCount;
        private bool IsHttpPresent()
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
            //_timer = new Timer(TimerOn, null, 0, 1);
            _timer = new Timer(TimerOn, null, 0, Timeout.Infinite);
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
