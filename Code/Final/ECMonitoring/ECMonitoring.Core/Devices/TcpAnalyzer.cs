using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECMonitoring.Core.Timings;
using SharpPcap;

namespace ECMonitoring.Core.Devices
{
    internal class TcpAnalyzer
    {
        private int _rstCount;
        private LanDeviceStatus _prvStatus;
        private SingleShot _singleShot;
        //private PingGeneratorPrv _pingGenerator;
        private LanNotification _pingGenerator;
        private object _syncObject;
        bool _isDisposed;

        public delegate void TcpAnalyzeCompleteHandler(object sender, LanDeviceStatus deviceStatus);
        public event TcpAnalyzeCompleteHandler TcpAnalyzeCompleteOn;

        public TcpAnalyzer(string srcIp)
        {
            _prvStatus = LanDeviceStatus.Sleep;
            _rstCount = 0;

            _singleShot = new SingleShot(false);
            _singleShot.Trigger += _singleShot_Trigger;

            //_pingGenerator = new PingGeneratorPrv(srcIp);
            _pingGenerator = new LanNotification(srcIp);
            _pingGenerator.PingErrorOn += _pingGenerator_PingErrorOn;
            _pingGenerator.PingReconnectionOn += _pingGenerator_PingReconnectionOn;

            _syncObject = new object();
        }

        public void Dispose()
        {
            lock (_syncObject)
            {
                _singleShot.Trigger -= _singleShot_Trigger;
                _pingGenerator.PingErrorOn -= _pingGenerator_PingErrorOn;
                _pingGenerator.PingReconnectionOn -= _pingGenerator_PingReconnectionOn;
                _singleShot.Dispose();
                _pingGenerator.Dispose();
                _isDisposed = true;
            }
        }

        private void _pingGenerator_PingErrorOn(object sender, string errorMessage)
        {
            lock (_syncObject)
            {
                if (_isDisposed)
                {
                    return;
                }

                _rstCount = 0;
                if (_prvStatus != LanDeviceStatus.Break)
                {
                    _prvStatus = LanDeviceStatus.Break;
                    TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Break);
                }
            }
        }

        private void _pingGenerator_PingReconnectionOn(object sender)
        {
            lock (_syncObject)
            {
                if (_isDisposed)
                {
                    return;
                }

                _prvStatus = LanDeviceStatus.Sleep;
                TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Sleep);
            }
        }

        private void _singleShot_Trigger()
        {
            lock (_syncObject)
            {
                if (_isDisposed)
                {
                    return;
                }

                if (_prvStatus != LanDeviceStatus.Connect)
                {
                    return;
                }

                _pingGenerator.Start();
                _rstCount = 0;
                _prvStatus = LanDeviceStatus.Sleep;
                TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Sleep);
            }
        }

        internal void Analyze(LanDeviceEventArgs device)
        {
            lock (_syncObject)
            {
                // тут 25.07.2020 ВОССТАНОВИТЬ ЭТОТ КОД !!!!!!!!!!!!!!!!!!!!!!!!!!
                //
                if (_isDisposed)
                {
                    return;
                }

                _singleShot.Start();
                _pingGenerator.Stop();

                if (!device.IsRst)
                {
                    _rstCount = 0;

                    if (_prvStatus != LanDeviceStatus.Connect)
                    {
                        _prvStatus = LanDeviceStatus.Connect;
                        TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Connect);
                    }
                }
                else
                {
                    if (_prvStatus != LanDeviceStatus.Disconnect)
                    {
                        if (_rstCount == 0)
                        {
                            _rstCount++;
                            return;
                        }
                        else
                        {
                            _rstCount = 0;
                            _prvStatus = LanDeviceStatus.Disconnect;
                            TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Disconnect);
                        }
                    }
                }
                return;
                //
                //// УБРАТЬ ЭТОТ КОД
                ////
                //TcpAnalyzeCompleteOn?.Invoke(this, LanDeviceStatus.Connect);
                //return;
            }
        }

        internal void PingExternalStart()
        {
            // 14.10.2020 УБРАТЬ ЭТОТ Комментарий без fake репозитория
            _pingGenerator.Start();
        }
    }
}
