using ECMonitoring.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void _btnApplay_Click(object sender, EventArgs e)
        {
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
                _endPoint.RowStatus = EndPointGridRowStatus.Modified;

                if (_endPointsCollection != null)
                {
                    _endPoint.RowStatus = EndPointGridRowStatus.Added;
                    _endPointsCollection.Add(_endPoint);
                }

                DialogResult = DialogResult.OK;
            }
        }
    }
}
