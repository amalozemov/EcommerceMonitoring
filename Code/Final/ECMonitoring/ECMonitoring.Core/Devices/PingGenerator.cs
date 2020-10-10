using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Devices
{
    enum PingStatus
    {
        Ok,
        Error
    }

    internal class PingGenerator
    {
        public delegate void PingErrorHandler(object sender, string errorMessage);
        public delegate void PingReconnectionHandler(object sender);
        public event PingErrorHandler PingErrorOn;
        public event PingReconnectionHandler PingReconnectionOn;

        public string Ip { get; private set; }
        private int _period { get; set; }
        private int _pingErrorsCountMax { get; set; }
        private Timer _timer { get; set; }
        private int _errosCount;
        private PingStatus _pingStatus;

        public PingGenerator(string ip, int period, int pingErrorsCountMax)
        {
            Ip = ip;
            _period = period;
            _pingErrorsCountMax = pingErrorsCountMax;
            _timer = new Timer(PingTo);
            _pingStatus = PingStatus.Ok;
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
                if (_errosCount > _pingErrorsCountMax)
                {
                    PingErrorOn?.Invoke(this, errorMessage);
                    _pingStatus = PingStatus.Error;
                }
                else
                {
                    _errosCount++;
                    ping.Dispose();
                    ping = null;
                    return;
                }
            }
            else if (_pingStatus == PingStatus.Error)
            {
                PingReconnectionOn?.Invoke(this);
                _pingStatus = PingStatus.Ok;
            }

            _errosCount = 0;
            ping.Dispose();
            ping = null;
        }

        public void Start()
        {
            _timer.Change(0, _period);
        }

        public void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
