using ECMonitoring.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMonitoring.Service.Forms
{
    partial class FormEndPoint : Form
    {
        EndPointGridRow _endPoint;
        List<EndPointGridRow> _endPointsCollection;
        IUnitOfWorkFactory _unitOfWorkFactory;

        private FormEndPoint(IUnitOfWorkFactory unitOfWorkFactory)
        {
            InitializeComponent();
            Text = "Создание конечной точки";
            _unitOfWorkFactory = unitOfWorkFactory;

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var monitorsTypes = repository.GetEntities<EndPointType>().ToList();
                _cmbMonitorType.DataSource = monitorsTypes;
                _cmbMonitorType.DisplayMember = "Description";
                _cmbMonitorType.ValueMember = "Value";

                var requestsTypes = 
                    repository.GetEntities<RequestContentsType>().ToList();
                _cmbRequesType.DataSource = requestsTypes;
                _cmbRequesType.DisplayMember = "Description";
                _cmbRequesType.ValueMember = "Value";
            }
        }

        public FormEndPoint(IUnitOfWorkFactory unitOfWorkFactory, EndPointGridRow endPoint) : this(unitOfWorkFactory)
        {
            _endPoint = endPoint;
            Text = "Изменение конечной точки";

            _txtEndPointName.Text = _endPoint.Name;
            _txtNetworkName.Text = _endPoint.NetworkName;
            _txtIp.Text = _endPoint.Ip;
            _txtPort.Text = _endPoint.Port.ToString();
            _cmbMonitorType.SelectedValue = endPoint.TypeMonitor;
            _cmbRequesType.SelectedValue = endPoint.RequestType;
        }

        public FormEndPoint(IUnitOfWorkFactory unitOfWorkFactory, List<EndPointGridRow> endPointsCollection) : this(unitOfWorkFactory)
        {
            _endPoint = new EndPointGridRow();
            _endPointsCollection = endPointsCollection;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckFieldsValue())
            {
                return;
            }

            using (var uow = _unitOfWorkFactory.Create())
            {
                _endPoint.Name = _txtEndPointName.Text.Trim();
                _endPoint.NetworkName = _txtNetworkName.Text.Trim();
                _endPoint.Ip = _txtIp.Text;
                _endPoint.Port = Convert.ToInt32(_txtPort.Text.Trim());

                var repository = uow.GetRepository();
                _endPoint.EndPointType =
                    repository.GetEntities<EndPointType>().Where(p => p.Value == (TypeEndPoint?)_cmbMonitorType.SelectedValue).FirstOrDefault();
                _endPoint.RequestContentsType =
                    repository.GetEntities<RequestContentsType>().Where(p => p.Value == (TypeRequestContents?)_cmbRequesType.SelectedValue).FirstOrDefault();
                if (_endPoint.RowStatus != EndPointGridRowStatus.Added)
                {
                    _endPoint.RowStatus = EndPointGridRowStatus.Modified;
                }

                if (_endPointsCollection != null)
                {
                    _endPoint.RowStatus = EndPointGridRowStatus.Added;
                    _endPointsCollection.Add(_endPoint);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private bool CheckFieldsValue()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_txtEndPointName.Text.Trim()))
                {
                    throw new Exception("Заполните поле ввода 'Название'.");
                }

                if (string.IsNullOrWhiteSpace(_txtNetworkName.Text.Trim()) && 
                    (TypeEndPoint)_cmbMonitorType.SelectedValue == TypeEndPoint.ResourceMonitor)
                {
                    throw new Exception("Заполните поле ввода 'Сетевое имя'.");
                }

                CheckIPAddress(_txtIp.Text);

                if (string.IsNullOrWhiteSpace(_txtPort.Text.Trim()))
                {
                    throw new Exception("Заполните поле ввода 'Port'.");
                }

                try
                {
                    var test = Convert.ToInt32(_txtPort.Text);
                }
                catch
                {
                    throw new Exception("В поле ввода 'Port' указаны некорректные значения.");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void CheckIPAddress(string addr)
        {
            addr = addr.Trim();
            if (string.IsNullOrWhiteSpace(addr))
            {
                throw new NullReferenceException("Заполните поле ввода 'Ip'.");
            }

            string pattern = "^(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])(.(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])){3}$";
            var ret = Regex.IsMatch(addr, pattern);
            if (ret == false)
            {
                throw new FormatException("Форма записи IP адреса не соответствует заданному.");
            }
        }
    }
}
