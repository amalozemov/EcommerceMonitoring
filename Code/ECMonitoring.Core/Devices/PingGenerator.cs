using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    internal class PingGenerator
    {
        public delegate void PingErrorHandler(object sender, string errorMessage);
        public event PingErrorHandler PingErrorOn;

        public string Ip { get; private set; }
        public int Period { get; private set; }
        Timer _timer { get; set; }
        int _errosCount;

        public PingGenerator(string ip, int period)
        {
            Ip = ip;
            Period = period;
            _timer = new Timer(PingTo);
        }

        public void Dispose()
        {
            Stop();
            _timer.Dispose();
            _timer = null;
        }

        private void PingTo(object state)
        {
            var address = Ip;
            var errorMessage = string.Empty;
            bool rez = false;
            var ping = new Ping();
            var pingReply = default(PingReply);

            try
            {
                pingReply = ping.Send(address, 100);
                rez = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            if (rez == true)
            {
                if (pingReply.Status == IPStatus.Success)
                {
                    //
                }
                else
                {
                    errorMessage = "Не успешный пинг.";
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                if (_errosCount > 10)
                {
                    PingErrorOn?.Invoke(this, errorMessage);
                }
                else
                {
                    _errosCount++;
                    ping.Dispose();
                    ping = null;
                    return;
                }
            }

            _errosCount = 0;
            ping.Dispose();
            ping = null;
        }

        public void Start()
        {
            _timer.Change(0, Period);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
