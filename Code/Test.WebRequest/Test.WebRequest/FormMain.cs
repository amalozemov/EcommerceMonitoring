using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.WebRequest.Properties;

// https://blog.foolsoft.ru/c-funkcii-post-i-get-zaprosov-gotovye-k-primen/
// МТТ: public object Handle(StartCallbackMessage message)
// https://metanit.com/sharp/net/2.2.php
// https://docs.microsoft.com/ru-ru/dotnet/api/system.net.networkcredential?view=netframework-4.8


namespace Test.WebRequest
{
    public partial class FormMain : Form
    {
        Timer _timer;
        TimeSpan _prviousTime;
        TimeSpan _currentTime;
        public FormMain()
        {
            InitializeComponent();

            Text = Application.ProductName;
            _timer = new Timer();
            _timer.Tick += _timer_Tick;

            

            _txtUrl.Text = Settings.Default.Url;
            _txtParams.Text = Settings.Default.Params;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            btnGo_Click(null, null);
            if (_currentTime > _prviousTime)
            {
                _prviousTime = _currentTime;
                _lblMaxTime.Text = $"Максимальное время (ms): {_currentTime}";
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                //throw new Exception("Ошибка");
                
                this.Enabled = false;

                var url = _txtUrl.Text + _txtParams.Text;
                var myCred = new NetworkCredential("alazarev_gmcs", "brBjK8uh", "office");

                var timer = new Stopwatch();
                timer.Start();

                var req = (HttpWebRequest)System.Net.WebRequest.Create(url);
                //req.Credentials = myCred;
                req.Method = "POST";
                //req.Accept = "application/json";
                req.ContentType = "application/json; charset=utf-8";
                req.ContentLength = 0;
                //WebResponse resp = req.GetResponse();
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                timer.Stop();
                _lblTimeRun.Text = $"Время выполнения: {timer.Elapsed}";
                _currentTime = timer.Elapsed;
                string res = sr.ReadToEnd();
                //_lblResult.Text = "Результат: " + GetResult(res);
                sr.Close();
                Console.WriteLine("Завершено.");
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_timer.Stop();
                this.Enabled = true;
            }
        }

        private string GetResult(string resp)
        {
            //Console.WriteLine(resp);
            //Console.WriteLine(resp.IndexOf("RUB"));
            var t = string.Empty;
            if (resp.Contains("RUB"))
                t = resp.Substring(0, resp.IndexOf("RUB", 0, StringComparison.OrdinalIgnoreCase) + 3);
            else
                t = resp.Substring(0, resp.IndexOf("руб", 0, StringComparison.OrdinalIgnoreCase) + 3);
            //Console.WriteLine(t);
            var t1 = t.Substring(t.LastIndexOf("text"));
            //Console.WriteLine(t1);
            var res = t1.Replace("text:", string.Empty).Replace("\"", string.Empty);
            //Console.WriteLine(res);

            return res;
        }

        private void _btnGo_Click(object sender, EventArgs e)
        {
            _timer.Interval = Convert.ToInt32(_txtPeriod.Text);
            _timer.Start();

            _btnGo.Enabled = false;
            _btnStop.Enabled = true;
        }

        private void _btnStop_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            _btnGo.Enabled = true;
            _btnStop.Enabled = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Url = _txtUrl.Text;
            Settings.Default.Params = _txtParams.Text;
            Settings.Default.Save();
        }
    }
}
