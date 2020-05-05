using DBaseService;
using ECMService.Core;
using ECMService.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMService
{
    public partial class FormMain : Form
    {
        IList<ClientEndPoint> _clientEndPoints;
        IRepository _repository;
        IStorage _storage;
        public bool IsConnected { get; private set; }
        System.Threading.Timer _timer { get; set; }
        
        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _clientEndPoints = new List<ClientEndPoint>();
            _repository = new FakeRepository();

            _timer = new System.Threading.Timer(GetEcmData);
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                Console.WriteLine("Устройство уже подключено.");
                return;
            }

            _storage = new MemoryStorage();

            var datas = _repository.GetServices();
            foreach (var services in datas)
            {
                var endpoints = _repository.GetEndPoints(services.Id);
                foreach (var endpoint in endpoints)
                {
                    var ep = new ClientEndPoint(endpoint.Ip, endpoint.Port, endpoint.Id, _storage);
                    _storage.AddEndoint(ep.Ip, ep.Port, ep.Id);
                    _clientEndPoints.Add(ep);
                    ep.Start();
                }
            }

            IsConnected = true;
            Console.WriteLine("Устройство подключено.");
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                Console.WriteLine("Устройство ещё не подключено.");
                return;
            }

            foreach (var ep in _clientEndPoints)
            {
                ep.Stop();
            }
            _clientEndPoints.Clear();
            _storage.Dispose();

            IsConnected = false;
            Console.WriteLine("Устройство отключено.");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _btnStopGetData_Click(null, null);
            _btnStop_Click(null, null);
        }

        private void _btnGetData_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                Console.WriteLine("Устройство ещё не подключено.");
                return;
            }

            //var id = 0;
            //var data = _storage.ExtractData("192.168.0.100", 1800, id);
            //Console.WriteLine($"Для конечной точки с Id = {id} состояние = {data.StatusLanDevice}");

            //foreach (var ep in _clientEndPoints)
            //{
            //    var data = _storage.ExtractData("192.168.0.100", 1800, ep.Id);
            //    Console.WriteLine($"Для конечной точки с Id = {ep.Id} состояние = {data.StatusLanDevice}");
            //}

            //GetEcmData(null);
            _timer.Change(0, 1);
        }

        void GetEcmData(object o)
        {
            foreach (var ep in _clientEndPoints)
            {
                var data = _storage.ExtractData("192.168.0.100", 1800, ep.Id);
                Console.WriteLine($"Для конечной точки с Id = {ep.Id} состояние = {data.StatusLanDevice}");
            }
        }

        private void _btnStopGetData_Click(object sender, EventArgs e)
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
    }
}
