﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;

namespace ECMonitoring.Core.Devices
{
    internal class TcpAnalyzer
    {
        private int _rstCount;
        private LanDeviceStatus _prvStatus;
        private SingleShot _singleShot;
        private PingGenerator _pingGenerator;
        private object _syncObject;

        public delegate void TcpAnalyzeCompleteHandler(object sender, LanDeviceStatus deviceStatus);
        public event TcpAnalyzeCompleteHandler TcpAnalyzeCompleteOn;

        bool _isDisposed;

        public TcpAnalyzer(string srcIp)
        {
            _prvStatus = LanDeviceStatus.Sleep;
            _rstCount = 0;
            _singleShot = new SingleShot(15000, false);
            _singleShot.Trigger += _singleShot_Trigger;

            _pingGenerator = new PingGenerator(srcIp, 500);
            _pingGenerator.PingErrorOn += _pingGenerator_PingErrorOn;

            _syncObject = new object();
        }

        public void Dispose()
        {
            lock (_syncObject)
            {
                _singleShot.Trigger -= _singleShot_Trigger;
                _pingGenerator.PingErrorOn -= _pingGenerator_PingErrorOn;
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
    }
}
