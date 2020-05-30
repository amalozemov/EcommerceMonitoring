using DBaseService;
using ECMService.DesctopClient.ServiceReference;
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
        System.Threading.Timer _timer { get; set; }

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _timer = new System.Threading.Timer(GetEcmData);

        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_clientService != null)
            {
                return;
            }
            
            //var x = 5;
            //var y = 4;

            _clientService = new ConnectorsClient("BasicHttpBinding_IConnectors");

            //Console.WriteLine(client.DoWork(x, y));

            //var t = client.GetDataByEndPointId(0);

            //Console.WriteLine($"TCP Status = {t.StatusLanDevice}; Http Errors Count = {t.HttpErrorsCount}");

            //client.Close();

            _timer.Change(0, 1);
        }

        void GetEcmData(object o)
        {
            //if (!ECMonitor.IsConnected)
            //{
            //    return;
            //}

            IRepository _repository = new FakeRepository();
            var services = _repository.GetServices();
            foreach (var service in services)
            {
                var endpoints = _repository.GetEndPoints(service.Id);
                foreach (var ep in endpoints)
                {
                    //var data = ECMonitor.GetDataByEndPointId(ep.Id);
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
    }
}
