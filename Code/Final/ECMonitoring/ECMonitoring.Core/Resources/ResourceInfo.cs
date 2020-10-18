using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Management;
using System.Net;
using ECMonitoring.Logger;
using System.Configuration;

namespace ECMonitoring.Core.Resources
{
    internal class ResourceInfo : IResourceInfo
    {
        public event ResourceStatusChangedHandler ResourceStatusChangedOn;
        private string _ip;
        private string _userName;
        private string _password;
        //private ManualResetEvent _waitObject;
        //private ManagementScope _managementScope;
        private bool _isResourcePlaceCurrentHost
        {
            get
            {
                return
                    Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(ip => ip.ToString() == _ip).FirstOrDefault() != null;
            }
        }
        private IEcmLogger _logger;
        private bool _isComplete;
        private bool _isStarted;
        private int _resourceInfoConnectWaiting;
        private int _repeatResourceRequestEvery;

        public ResourceInfo(string ip, string userName, string password)
        {
            _resourceInfoConnectWaiting =
                Convert.ToInt32(ConfigurationManager.AppSettings["ResourceInfoConnectWaiting"]);
            _repeatResourceRequestEvery =
                Convert.ToInt32(ConfigurationManager.AppSettings["RepeatResourceRequestEvery"]);
            //_waitObject = new ManualResetEvent(true);
            _ip = ip;
            _userName = userName;
            _password = password;
            _logger = new EcmLogger("Core-ResourceInfo");
        }

        public void Start()
        {
            if (!_isStarted)
            {
                _isStarted = true;
                _isComplete = false;
                GetResources();
            }
        }

        public void Stop()
        {
            if (_isStarted)
            {
                _isComplete = true;
                //_waitObject.WaitOne();
                DisconnectFromResource();
                _isStarted = false;
            }
        }

        private void GetResources()
        {
            while (!_isComplete)
            {
                var resourceUsageEventArgs = new ResourceUsageEventArgs();

                try
                {
                    //_waitObject.Reset();

                    var managementScope = ConnectToResource();

                    // получение памяти ПК
                    var ramMonitor =
                        new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory,FreeVirtualMemory,TotalVirtualMemorySize FROM Win32_OperatingSystem");
                    if (managementScope != null)
                    {
                        ramMonitor.Scope = managementScope;
                    }
                    var paramRam = ramMonitor.Get().Cast<ManagementObject>().FirstOrDefault();
                    if (paramRam != null)
                    {
                        resourceUsageEventArgs.FreePhysicalMemory = Convert.ToDouble(paramRam["FreePhysicalMemory"]);
                        resourceUsageEventArgs.FreeVirtualMemory = Convert.ToDouble(paramRam["FreeVirtualMemory"]);
                        resourceUsageEventArgs.TotalVirtualMemorySize = Convert.ToDouble(paramRam["TotalVirtualMemorySize"]);
                        resourceUsageEventArgs.TotalVisibleMemorySize = Convert.ToDouble(paramRam["TotalVisibleMemorySize"]);
                        _logger.Trace($"Ресурс {_ip}, получены данные о памяти: Занято: " +
                            $"{resourceUsageEventArgs.BusyPhysicalMemory / 1000 / 1000:N1}Гб ({resourceUsageEventArgs.BusyPhysicalMemoryPercent:N1}%)");
                    }
                    else
                    {
                        _logger.Warn($"Ресурс {_ip}, не удалось получить данные о памяти");
                    }

                    // получение процента загрузки процессора ПК
                    var procMonitor =
                        new ManagementObjectSearcher("SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");
                    if (managementScope != null)
                    {
                        procMonitor.Scope = managementScope;
                    }
                    var paramProc = procMonitor.Get().Cast<ManagementObject>().FirstOrDefault();
                    if (paramProc != null)
                    {
                        resourceUsageEventArgs.PercentIdleTime = Convert.ToDouble(paramProc["PercentIdleTime"]);
                        resourceUsageEventArgs.PercentProcessorTime = Convert.ToDouble(paramProc["PercentProcessorTime"]);
                        _logger.Trace($"Ресурс {_ip}, получены данные о загрузке процессора: {resourceUsageEventArgs.PercentProcessorTime:N1}%");
                    }
                    else
                    {
                        _logger.Warn($"Ресурс {_ip}, не удалось получить данные о загрузке процессора");
                    }
                }
                catch (Exception ex)
                {
                    resourceUsageEventArgs.IsSuccess = false;
                    _logger.Error($"При обращении к ресурсу {_ip} произошла ошибка:{Environment.NewLine}{ex}");
                }
                finally
                {
                    ResourceStatusChangedOn?.BeginInvoke(this, resourceUsageEventArgs, null, null);
                    //_waitObject.Set();
                }

                Thread.Sleep(_repeatResourceRequestEvery);
            }
        }

        private ManagementScope ConnectToResource()
        {
            _logger.Trace($"Начата попытка подключения ресурса: {_ip}");
            var managementScope = default(ManagementScope);
            if (!_isResourcePlaceCurrentHost)
            {
                var co = new ConnectionOptions();
                co.Username = _userName;
                co.Password = _password;
                co.Impersonation = ImpersonationLevel.Impersonate;
                co.Authentication = AuthenticationLevel.PacketPrivacy;
                co.EnablePrivileges = true;
                co.Timeout = new TimeSpan(_resourceInfoConnectWaiting);
                managementScope = new ManagementScope($"\\\\{_ip}\\root\\cimv2", co);
                managementScope.Connect();
                _logger.Trace($"Подключение ресурса {_ip} выполнено");
            }
            else
            {
                _logger.Trace($"Подключение ресурса {_ip} не выполнялось");
            }
            return managementScope;
        }

        private void DisconnectFromResource()
        {
            //_logger.Trace($"Начата попытка отключения от ресурса: {_ip}");
            //if (_managementScope != null)
            //{
            //    _managementScope = null;
                _logger.Trace($"Отключение ресурса {_ip} выполнено");
            //}
            //else
            //{
            //    _logger.Trace($"Отключение от ресурса {_ip} не выполнялось");
            //}
        }
    }
}
