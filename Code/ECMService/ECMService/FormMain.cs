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
        //List<ClientService> _clientServices;
        IList<ClientEndPoint> _clientEndPoints;
        IRepository _repository;
        IStorage _storage;
        public bool IsConnected { get; private set; }

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            //_clientServices = new List<ClientEndPoint>();
            _clientEndPoints = new List<ClientEndPoint>();
            _repository = new FakeRepository();
            //_storage = new MemoryStorage();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            if (IsConnected)
            {
                Console.WriteLine("Устройство уже подключено.");
                return;
            }

            var datas = _repository.GetServices();
            _storage = new MemoryStorage();

            foreach (var services in datas)
            {
                //var service = new ClientService()
                //{
                //    Id = data.Id,
                //    Name = data.Name,
                //};
                //service.CreateEndPoints(_repository);
                //_clientServices.Add(service);
                //service.Start();
                var endpoints = _repository.GetEndPoints(services.Id);
                foreach (var endpoint in endpoints)
                {
                    var ep = new ClientEndPoint(endpoint.Ip, endpoint.Port, _storage);
                    _storage.AddEndoint(ep.Ip);
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
            _btnStop_Click(null, null);
        }
    }
}
