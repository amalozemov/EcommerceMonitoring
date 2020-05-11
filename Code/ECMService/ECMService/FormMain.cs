using DBaseService;
using ECMService.Core;
using System;
using System.Windows.Forms;

namespace ECMService
{
    public partial class FormMain : Form
    {
        System.Threading.Timer _timer { get; set; }
        ECMonitor _ecMonitor;

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _timer = new System.Threading.Timer(GetEcmData);

            _ecMonitor = new ECMonitor();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (_ecMonitor.IsConnected)
            {
                Console.WriteLine("Устройство уже подключено.");
                return;
            }

            _ecMonitor.Start();

            Console.WriteLine("Устройство подключено.");
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            if (!_ecMonitor.IsConnected)
            {
                Console.WriteLine("Устройство ещё не подключено.");
                return;
            }

            _ecMonitor.Stop();

            Console.WriteLine("Устройство отключено.");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _btnStopGetData_Click(null, null);
            _btnStop_Click(null, null);
        }

        private void _btnGetData_Click(object sender, EventArgs e)
        {
            if (!_ecMonitor.IsConnected)
            {
                Console.WriteLine("Устройство ещё не подключено.");
                return;
            }

            _timer.Change(0, 1);
        }

        void GetEcmData(object o)
        {
            if (!_ecMonitor.IsConnected)
            {
                return;
            }

            IRepository _repository = new FakeRepository();
            var services = _repository.GetServices();
            foreach (var service in services)
            {
                var endpoints = _repository.GetEndPoints(service.Id);
                foreach (var ep in endpoints)
                {
                    var data = _ecMonitor.GetDataByEndPointId(ep.Id);
                    Console.WriteLine($"Для конечной точки с Id = {ep.Id} состояние = {data?.StatusLanDevice}");
                }
            }
        }

        private void _btnStopGetData_Click(object sender, EventArgs e)
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
    }
}
