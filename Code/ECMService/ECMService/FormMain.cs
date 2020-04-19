using DBaseService;
using ECMService.Core;
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
        List<ClientService> _clientServices;
        IRepository _repository;


        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            _clientServices = new List<ClientService>();
            _repository = new FakeRepository();
        }

        private void _btnStart_Click(object sender, EventArgs e)
        {
            var datas = _repository.GetServices();

            foreach (var data in datas)
            {
                var service = new ClientService()
                {
                    Id = data.Id,
                    Name = data.Name
                };
                service.CreateEndPoints(_repository);
                _clientServices.Add(service);
                service.Start();
            }
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            foreach (var cs in _clientServices)
            {
                cs.Stop();
            }

            _clientServices.Clear();
        }
    }
}
