using DBaseService;
using ECMService.DesctopClient.ServiceReference;
using ECMService.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMService.DesctopClient
{
    public partial class FormMain : Form
    {
        ConnectorsClient _clientService;
        System.Threading.Timer _timer;
        System.Threading.Timer _timer2;
        System.Threading.Timer _timer3;
        ECMonitor _esMonitor;

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _timer = new System.Threading.Timer(GetEcmData);
            _timer2 = new System.Threading.Timer(GetAllEndPointDataFromManager);
            _timer3 = new System.Threading.Timer(GetAllServicesDataFromManager);

            _esMonitor = new ECMonitor();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_clientService != null)
            {
                return;
            }

            _clientService = new ConnectorsClient("BasicHttpBinding_IConnectors");

            _timer.Change(0, 100);
        }

        void GetEcmData(object o)
        {
            IRepository _repository = new FakeRepository();
            var services = _repository.GetServices();
            foreach (var service in services)
            {
                var endpoints = _repository.GetEndPoints(service.Id);
                foreach (var ep in endpoints)
                {
                    var data = _clientService.GetDataByEndPointId(ep.Id);
                    Console.WriteLine($"Для конечной точки с Id = {ep.Id} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}; MemoryUsage = {data?.MemoryUsage}; ProcessorTime = {data?.ProcessorTime}");
                }
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _clientService.Close();
            _clientService = null;
        }

        private void _btnGetDataFromManager_Click(object sender, EventArgs e)
        {
            var endPointId = 0;
            var data = _esMonitor.GetEndPointData(endPointId);

            Console.WriteLine($"Для конечной точки с Id = {endPointId} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}; MemoryUsage = {data?.MemoryUsage}; ProcessorTime = {data?.ProcessorTime}");
        }

        bool _isDataRecieved;
        private void _btnGetDataFromManagerAllAndPoints_Click(object sender, EventArgs e)
        {
            if (_isDataRecieved)
            {
                _isDataRecieved = false;
                _timer2.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }

            _isDataRecieved = true;
            _timer2.Change(0, 100);
        }

        private void GetAllEndPointDataFromManager(object o)
        {
            IRepository _repository = new FakeRepository();
            var services = _repository.GetServices();
            foreach (var service in services)
            {
                var endpoints = _repository.GetEndPoints(service.Id);
                foreach (var ep in endpoints)
                {
                    //var data = _esMonitor.GetEndPointData(ep.Id);
                    //Console.WriteLine($"Для конечной точки с Id = {ep.Id} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}");
                    new Task(() =>
                    {
                        var data = _esMonitor.GetEndPointData(ep.Id);
                        Console.WriteLine($"Для конечной точки с Id = {ep.Id} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}; MemoryUsage = {data?.MemoryUsage}; ProcessorTime = {data?.ProcessorTime}");
                    }).Start();
                }
            }
        }

        private void _btnGetDataFromManagerByService_Click(object sender, EventArgs e)
        {
            var srviceId = 0;
            var srviceData = _esMonitor.GetServiceData(srviceId);

            foreach (var data in srviceData.EndPointsData)
            {
                Console.WriteLine($"Для конечной точки с Id = {data.EndPointId} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}; MemoryUsage = {data?.MemoryUsage}; ProcessorTime = {data?.ProcessorTime}");
            }
        }

        bool _isDataRecieved2;
        private void _btnGetDataFromManagerByAllServices_Click(object sender, EventArgs e)
        {
            if (_isDataRecieved2)
            {
                _isDataRecieved2 = false;
                _timer3.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            }

            _isDataRecieved2 = true;
            _timer3.Change(0, 100);
        }

        private void GetAllServicesDataFromManager(object o)
        {
            IRepository _repository = new FakeRepository();
            var services = _repository.GetServices();

            foreach (var service in services)
            {
                new Task(() =>
                {
                    var srviceData = _esMonitor.GetServiceData(service.Id);
                    foreach (var data in srviceData.EndPointsData)
                    {
                        Console.WriteLine($"Для конечной точки с Id = {data.EndPointId} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}; MemoryUsage = {data?.MemoryUsage}; ProcessorTime = {data?.ProcessorTime}");
                    }
                }).Start();
            }
        }
    }
}
