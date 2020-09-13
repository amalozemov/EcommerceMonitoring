using ECMonitoring.Data;
using ECMonitoring.Data.EF;
using ECMonitoring.Service.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMonitoring.Service.Forms
{
    public partial class FormMain : Form
    {
        IUnitOfWorkFactory _unitOfWorkFactory;
        Dispatcher _dispatcher;
        ServiceHost _host;

        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;

            var connectionString =
                ConfigurationManager.ConnectionStrings["ECMonitoring"].ConnectionString;
            _unitOfWorkFactory = new UnitOfWorkFactory(connectionString);
            _dispatcher = new Dispatcher(_unitOfWorkFactory);
            var ecmService = new ECMService(_dispatcher);
            _host = new ServiceHost(ecmService);
            _host.Open();

            SetHostStatus();
            SetCoreStatus();

            //_mnuRun_Click(null, null);
        }

        private void SetHostStatus()
        {
            if (_host.State != CommunicationState.Closed &&
                _host.State != CommunicationState.Closing &&
                _host.State != CommunicationState.Faulted)
            {
                _lblHostStatus.Text = "Работает";
                _lblHostStatus.ForeColor = Color.FromArgb(0, 128, 0);
                Console.WriteLine("ECMService стартован...");
            }
            else
            {
                _lblHostStatus.Text = "Остановлен";
                _lblHostStatus.ForeColor = Color.FromArgb(192, 0, 0);
                Console.WriteLine("ECMService остановлен.");
            }
        }

        private void SetCoreStatus()
        {
            if (_dispatcher.IsConnected)
            {
                _lblCoreStatus.Text = "Работает";
                _lblCoreStatus.ForeColor = Color.FromArgb(0, 128, 0);
                _lblAmountEndPoints.Text = _dispatcher.GetEndPointsCount().ToString();
                _lblAmountEndPointsDes.Visible = true;
                _lblAmountEndServices.Text = _dispatcher.GetServicesCount().ToString();
                _lblAmountEndServicesDes.Visible = true;
                _mnuRun.Enabled = false;
                _mnuStop.Enabled = true;
                Console.WriteLine("ECMonitor стартован...");
            }
            else
            {
                _lblCoreStatus.Text = "Остановлено";
                _lblCoreStatus.ForeColor = Color.FromArgb(192, 0, 0);
                _lblAmountEndPoints.Text = string.Empty;
                _lblAmountEndPointsDes.Visible = false;
                _lblAmountEndServices.Text = string.Empty;
                _lblAmountEndServicesDes.Visible = false;
                _mnuRun.Enabled = true;
                _mnuStop.Enabled = false;
                Console.WriteLine("ECMonitor остановлен.");
            }
        }

        private void _mnuRun_Click(object sender, EventArgs e)
        {
            if (_dispatcher.IsConnected)
            {
                Console.WriteLine("ECMonitor уже подключен.");
                return;
            }

            _dispatcher.Start();

            SetCoreStatus();
        }

        private void _mnuStop_Click(object sender, EventArgs e)
        {
            if (!_dispatcher.IsConnected)
            {
                Console.WriteLine("ECMonitor ещё не подключен.");
                return;
            }

            _dispatcher.Stop();
            SetCoreStatus();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _host.Close();
        }

        private void _mnuAppExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _mnuServices_Click(object sender, EventArgs e)
        {
            if (_dispatcher.IsConnected)
            {
                MessageBox.Show("Для настройки приложения необходимо остановить ядро.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var form = new FormServicesList(_unitOfWorkFactory);
            form.ShowDialog();
        }
    }
}
