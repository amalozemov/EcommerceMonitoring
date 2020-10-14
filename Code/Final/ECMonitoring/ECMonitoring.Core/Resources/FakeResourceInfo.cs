using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECMonitoring.Core.Resources
{
    internal class FakeResourceInfo : IResourceInfo
    {
        public event ResourceStatusChangedHandler ResourceStatusChangedOn;
        private string _ip;
        private string _userName;
        private string _password;
        private ManualResetEvent _waitObject;
        bool _isResourcePlaceCurrentHost = false;
        bool _isComplete;
        bool _isStarted;

        public FakeResourceInfo(string ip, string userName, string password)
        {
            _waitObject = new ManualResetEvent(true);
            _ip = ip;
            _userName = userName;
            _password = password;
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
                _waitObject.WaitOne();
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
                    _waitObject.Reset();

                    ConnectToResource();
                    
                    // получение памяти ПК
                    var paramRam = true;
                    if (paramRam)
                    {
                        resourceUsageEventArgs.FreePhysicalMemory = 100f;
                        resourceUsageEventArgs.FreeVirtualMemory = 1000f;
                        resourceUsageEventArgs.TotalVirtualMemorySize = 5000f;
                        resourceUsageEventArgs.TotalVisibleMemorySize = 400f;
                        Console.WriteLine($"С ресурса {_ip} получены данные о памяти: Занято: " +
                            $"{resourceUsageEventArgs.BusyPhysicalMemory / 1000 / 1000:N1}Гб ({resourceUsageEventArgs.BusyPhysicalMemoryPercent:N1}%)");
                    }
                    else
                    {
                        Console.WriteLine($"С ресурса {_ip} не удалось получить данные о памяти");
                    }

                    // получение процента загрузки процессора ПК
                    var paramProc = true;
                    if (paramProc == true)
                    {
                        resourceUsageEventArgs.PercentIdleTime = 77f;
                        resourceUsageEventArgs.PercentProcessorTime = 23f;
                        Console.WriteLine($"С ресурса {_ip} получены данные о загрузке процессора: {resourceUsageEventArgs.PercentProcessorTime:N1}%");
                    }
                    else
                    {
                        Console.WriteLine($"С ресурса {_ip} не удалось получить данные о загрузке процессора");
                    }
                }
                catch (Exception ex)
                {
                    resourceUsageEventArgs.IsSuccess = false;
                    Console.WriteLine($"При обращении к ресурсу {_ip} произошла ошибка:{Environment.NewLine}{ex}");
                }
                finally
                {
                    ResourceStatusChangedOn?.BeginInvoke(this, resourceUsageEventArgs, null, null);
                    _waitObject.Set();
                }
                Thread.Sleep(1000);
            }
        }

        void ConnectToResource()
        {
            //try
            //{
                Console.WriteLine($"Начата попытка подключения к ресурсу: {_ip}");
                if (!_isResourcePlaceCurrentHost)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"Подключение к ресурсу {_ip} выполнено");
                }
                else
                {
                    Console.WriteLine($"Подключение к ресурсу {_ip} не выполнялось");
                }
                //return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"При подключении к ресурсу {_ip} произошла ошибка:{Environment.NewLine}{ex}");
            //    return false;
            //}
        }

        private void DisconnectFromResource()
        {
            Console.WriteLine($"Начата попытка отключения от ресурса: {_ip}");
            if (!_isResourcePlaceCurrentHost)
            {
                Console.WriteLine($"Отключение от ресурса {_ip} выполнено");
            }
            else
            {
                Console.WriteLine($"Отключение от ресурса {_ip} не выполнялось");
            }
        }
    }
}
