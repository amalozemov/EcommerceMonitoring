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
        ECMonitor _esMonitor;

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _timer = new System.Threading.Timer(GetEcmData);

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
                    Console.WriteLine($"Для конечной точки с Id = {ep.Id} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}");
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
            var data = default(EndPointDataDTO);

            var endPointId = 0;
            var result = _esMonitor.GetDataByEndPointId(endPointId, out data);
            if (result == ResultOperation.NoChange)
            {
                Console.WriteLine("Состояние конечной точки не изменилось");
            }
            else
            {
                Console.WriteLine($"Для конечной точки с Id = {endPointId} TCP Status = {data?.StatusLanDevice};  Http Errors Count = {data?.HttpErrorsCount}");
            }
        }
    }
}
