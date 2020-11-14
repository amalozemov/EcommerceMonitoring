using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Timings
{
    internal class PingGenerator
    {
        static PingGenerator _instance;
        List<IPingNotification> _observers;
        static object _syncRoot = new object();
        Timer _timer;
        int _period;
        int _pingWaitingResponse;

        private PingGenerator()
        {
            _observers = new List<IPingNotification>();

            _period =
                Convert.ToInt32(ConfigurationManager.AppSettings["RepeatPingEvery"]);
            _pingWaitingResponse =
                Convert.ToInt32(ConfigurationManager.AppSettings["PingWaitingResponse"]);
            _timer =
                new Timer(TimerTick, null, 0, _period); 
        }
        //
        public static PingGenerator Get()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    _instance = new PingGenerator();
                }
            }
            return _instance;
        }

        public void Register(IPingNotification observer)
        {
            new Action(delegate ()
            {
                lock (_syncRoot)
                {
                    _observers.Add(observer);
                }
            }).BeginInvoke(null, null);
        }

        public void UnRegister(IPingNotification observer)
        {
            new Action(delegate ()
            {
                lock (_syncRoot)
                {
                    if (_observers.Contains(observer))
                    {
                        _observers.Remove(observer);
                    }
                }
            }).BeginInvoke(null, null);
        }

        private void TimerTick(object state)
        {
            lock (_syncRoot)
            {
                var workItems = _observers.GroupBy(p => p.Ip).Select(g => g.Key);
                var pingResults = (from ip in workItems.AsParallel()
                                 select PingTo(ip)).ToList();

                var actions = new List<Action>(pingResults.Count);
                actions.AddRange(pingResults.Select(pingResult => new Action(() => {
                    var pingRecipients = _observers.Where(o => o.Ip == pingResult.Ip);
                    foreach (var recipient in pingRecipients)
                    {
                        recipient.PingOn(pingResult.Result);
                    }
                })));
                Parallel.Invoke(actions.ToArray());
            }
        }

        PingResult PingTo(string address)
        {
            var ret = new PingResult()
            {
                Ip = address,
                Result = PingStatus.Error
            };
            Ping ping = new Ping();
            PingReply pingReply = null;

            try
            {
                pingReply = ping.Send(address, _pingWaitingResponse);
                ret.Result = PingStatus.Ok;
            }
            catch{ }

            if (ret.Result == PingStatus.Ok)
            {
                if (pingReply.Status != IPStatus.Success)
                {
                    ret.Result = PingStatus.Error;
                }
            }
            ping.Dispose();
            ping = null;

            return ret; 
        }
    }

    class PingResult
    {
        public string Ip { get; set; }
        public PingStatus Result { get; set; }
    }
}
