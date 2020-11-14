using SharpPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanDevicesEnumerator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Text = Application.ProductName;
            _btnClearDevicesList.Enabled = false;
        }

        private void _btnGetDevicesList_Click(object sender, EventArgs e)
        {
            var devices = CaptureDeviceList.Instance;

            foreach (var device in devices)
            {
                _txtDevicesList.AppendText($"Имя: {device.Name}{Environment.NewLine}");
                _txtDevicesList.AppendText($"Описание: {device.Description}{Environment.NewLine}");
                _txtDevicesList.AppendText($"{Environment.NewLine}");
            }

            _btnGetDevicesList.Enabled = false;
            _btnClearDevicesList.Enabled = true;
        }

        private void _btnClearDevicesList_Click(object sender, EventArgs e)
        {
            _txtDevicesList.Clear();

            _btnGetDevicesList.Enabled = true;
            _btnClearDevicesList.Enabled = false;
        }
    }
}
