using PingGenerator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingGenerator
{
    public partial class FormMain : Form
    {
        System.Threading.Timer _timer { get; set; }

        public FormMain()
        {
            InitializeComponent();

            this.Text = Application.ProductName;
            btnStop.Enabled = false;
            txtDstIP.Text = Settings.Default.DstIp;
            txtPeriod.Text = Settings.Default.Period.ToString();


            
            _timer = new System.Threading.Timer(PingTo);
            //_timer.Tick += PingTo;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //_timer.Interval = Convert.ToInt32(txtPeriod.Text);
            //_timer.Start();
            _timer.Change(0, Convert.ToInt32(txtPeriod.Text));

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        //public void PingTo(object sender, EventArgs e)
        public void PingTo(object o)
        {
            var address = txtDstIP.Text;
            var errorMessage = string.Empty;
            bool rez = false;
            var ping = new Ping();
            var pingReply = default(PingReply);

            try
            {
                pingReply = ping.Send(address, 100);
                rez = true;
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
            }
            if (rez == true)
            {
                if (pingReply.Status == IPStatus.Success)
                {
                    lblStatus.Invoke(new Action(delegate { lblStatus.Text = "Пинг успешный."; }));
                    lblStatus.Invoke(new Action(delegate { lblStatus.ForeColor = Color.FromArgb(0, 128, 0); }));
                }
                else
                {
                    errorMessage = "Пинг не успешный.";
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                lblStatus.Invoke(new Action(delegate { lblStatus.Text = $"Ошибка: {errorMessage}"; }));
                lblStatus.Invoke(new Action(delegate { lblStatus.ForeColor = Color.FromArgb(255, 0, 0); }));
            }

            ping.Dispose();
            ping = null; 
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.DstIp = this.txtDstIP.Text;
            Settings.Default.Period = Convert.ToInt32(this.txtPeriod.Text);
            Settings.Default.Save();
        }
    }
}
