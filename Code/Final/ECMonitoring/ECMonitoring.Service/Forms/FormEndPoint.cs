using ECMonitoring.Data;
using ECMonitoring.Data.Cryptography;
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
            Text = "Изменение конечной точки";
            _endPoint = endPoint;

            _txtConnectorName.Text = endPoint.ConnectorName;
            _txtEndPointName.Text = _endPoint.Name;
            _txtNetworkName.Text = _endPoint.NetworkName;
            _txtIp.Text = _endPoint.Ip;
            _txtPort.Text = _endPoint.Port.ToString();
            _cmbMonitorType.SelectedValue = endPoint.TypeMonitor;
            _cmbRequesType.SelectedValue = endPoint.RequestType;
            _chkIsDisabledEndPoint.Checked = 
                endPoint.IsDisabledEndPoint.HasValue ? endPoint.IsDisabledEndPoint.Value : false;
            _txtHostUserName.Text = endPoint.HostUserName;
            _txtHostPassword.Text = !string.IsNullOrWhiteSpace(endPoint.HostPassword) ?
                new SHA1Encryption().DecryptData(endPoint.HostPassword) : string.Empty;
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
                _endPoint.ConnectorName = _txtConnectorName.Text.Trim();
                _endPoint.Name = _txtEndPointName.Text.Trim();
                _endPoint.NetworkName = _txtNetworkName.Text.Trim();
                _endPoint.Ip = _txtIp.Text.Trim();
                _endPoint.Port = !string.IsNullOrWhiteSpace(_txtPort.Text.Trim()) ? 
                    (int?)Convert.ToInt32(_txtPort.Text.Trim()) : null;
                _endPoint.IsDisabledEndPoint = _chkIsDisabledEndPoint.Checked;
                _endPoint.HostUserName = _txtHostUserName.Text.Trim();
                _endPoint.HostPassword = !string.IsNullOrWhiteSpace(_txtHostPassword.Text.Trim()) ?
                    new SHA1Encryption().EncryptData(_txtHostPassword.Text.Trim()) : string.Empty;

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
                // коннектор
                if ((TypeEndPoint)_cmbMonitorType.SelectedValue == TypeEndPoint.LanMonitor)
                {
                    if (string.IsNullOrWhiteSpace(_txtConnectorName.Text.Trim()))
                    {
                        throw new Exception("Заполните поле ввода 'Имя коннектора'.");
                    }
                }

                if (string.IsNullOrWhiteSpace(_txtEndPointName.Text.Trim()))
                {
                    throw new Exception("Заполните поле ввода 'Название'.");
                }

                //if (string.IsNullOrWhiteSpace(_txtNetworkName.Text.Trim()) && 
                //    (TypeEndPoint)_cmbMonitorType.SelectedValue == TypeEndPoint.ResourceMonitor)
                //{
                //    throw new Exception("Заполните поле ввода 'Сетевое имя'.");
                //}

                CheckIPAddress(_txtIp.Text);

                // порт
                if ((TypeEndPoint)_cmbMonitorType.SelectedValue == TypeEndPoint.LanMonitor)
                {
                    if (string.IsNullOrWhiteSpace(_txtPort.Text.Trim()))
                    {
                        throw new Exception("Заполните поле ввода 'Port'.");
                    }
                }
                if (!string.IsNullOrWhiteSpace(_txtPort.Text.Trim()))
                {
                    try
                    {
                        var test = Convert.ToInt32(_txtPort.Text.Trim());
                    }
                    catch
                    {
                        throw new Exception("В поле ввода 'Port' указаны некорректные значения.");
                    }
                }

                // логин и пароль хоста
                if ((TypeEndPoint)_cmbMonitorType.SelectedValue == TypeEndPoint.ResourceMonitor)
                {
                    if (string.IsNullOrWhiteSpace(_txtHostUserName.Text.Trim()))
                    {
                        throw new Exception("Заполните поле ввода 'Логин хоста'.");
                    }
                    if (string.IsNullOrWhiteSpace(_txtHostPassword.Text.Trim()))
                    {
                        throw new Exception("Заполните поле ввода 'Пароль хоста'.");
                    }
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
