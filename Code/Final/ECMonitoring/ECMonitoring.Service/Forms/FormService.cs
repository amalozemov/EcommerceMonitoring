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
    public partial class FormService : Form
    {
        Data.Service _service;
        List<Data.Service> _servicesColection;
        BindingSource _endPointBinding { get; set; }
        IUnitOfWorkFactory _unitOfWorkFactory;
        List<EndPointGridRow> _deletedRows;

        private FormService()
        {
            InitializeComponent();
            _deletedRows = new List<EndPointGridRow>();
            DgvEndPointsFill();
        }

        public FormService(IUnitOfWorkFactory unitOfWorkFactory) : this()
        {
            Text = "Создание сервиса";
            _unitOfWorkFactory = unitOfWorkFactory;

            _endPointBinding = new BindingSource();
            _endPointBinding.DataSource = new List<EndPointGridRow>();
            _dgvEndPointsList.DataSource = _endPointBinding;
        }

        public FormService(IUnitOfWorkFactory unitOfWorkFactory, List<Data.Service> services) : this(unitOfWorkFactory)
        {
            _service = new Data.Service();
            _servicesColection = services;
        }

        public FormService(IUnitOfWorkFactory unitOfWorkFactory, Data.Service service) : this(unitOfWorkFactory)
        {
            Text = "Изменение сервиса";
            _service = service;
            _txtServiceName.Text = _service.Name;
            _txtSequnceNumber.Text = _service.SequenceNumber.Value.ToString();

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                _endPointBinding.DataSource = 
                    repository.GetEntities<EndPoint>().Where(e => e.ServiceId == _service?.Id).ToList().Select(p => 
                    new EndPointGridRow() {
                        Id = p.Id,
                        Name = p.Name,
                        EndPointType = p.EndPointType,
                        EndPointTypeId = p.EndPointTypeId,
                        Ip = p.Ip,
                        NetworkName = p.NetworkName,
                        Port = p.Port,
                        RequestContentsType = p.RequestContentsType,
                        RequestContentsTypeId = p.RequestContentsTypeId,
                        RowStatus = (int)EndPointGridRowStatus.Unchanged,
                        Service = p.Service,
                        ServiceId = p.ServiceId
                    }).ToList();
                _dgvEndPointsList.DataSource = _endPointBinding;
            }
        }

        private void _btnApplay_Click(object sender, EventArgs e)
        {
            if (!CheckFieldsValue())
            {
                return;
            }

            _service.SequenceNumber = Convert.ToInt32(_txtSequnceNumber.Text);
            _service.Name = _txtServiceName.Text;

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var service = repository.FindById<Data.Service>(_service.Id);
                if (service == null)
                {
                    service = new Data.Service();
                    repository.Add(service);
                }

                service.SequenceNumber = _service.SequenceNumber;
                service.Name = _service.Name;

                DeleteEndPoints(repository);
                CreateEndPoints(service, repository);
                UpdateEndPoints(repository);

                uow.Commit();

                if (_servicesColection != null)
                {
                    _servicesColection.Add(service);
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void DeleteEndPoints(ICommonRepository repository)
        {
            foreach (var templateEndPoint in _deletedRows)
            {
                var deletedEndPoint = repository.FindById<EndPoint>(templateEndPoint.Id);
                repository.Delete(deletedEndPoint);
            }
        }

        private void CreateEndPoints(Data.Service service, ICommonRepository repository)
        {
            var addedRows =
                ((List<EndPointGridRow>)((BindingSource)_dgvEndPointsList.DataSource).DataSource).Where(p => p.RowStatus == EndPointGridRowStatus.Added);
            foreach (var templateEndPoint in addedRows)
            {
                repository.Add(new EndPoint()
                {
                    Service = service,
                    Name = templateEndPoint.Name,
                    NetworkName = templateEndPoint.NetworkName,
                    Ip = templateEndPoint.Ip,
                    Port = templateEndPoint.Port,
                    EndPointType =
                        repository.FindById<EndPointType>(templateEndPoint.EndPointType.Id),
                    RequestContentsType =
                        repository.FindById<RequestContentsType>(templateEndPoint.RequestContentsType.Id)
                });
            }
        }

        private void UpdateEndPoints(ICommonRepository repository)
        {
            var modifiedRows = 
                ((List<EndPointGridRow>)((BindingSource)_dgvEndPointsList.DataSource).DataSource).Where(p => p.RowStatus == EndPointGridRowStatus.Modified);
            foreach (var templateEndPoint in modifiedRows)
            {
                var updatedEndPoint = repository.FindById<EndPoint>(templateEndPoint.Id);
                updatedEndPoint.Name = templateEndPoint.Name;
                updatedEndPoint.NetworkName = templateEndPoint.NetworkName;
                updatedEndPoint.Ip = templateEndPoint.Ip;
                updatedEndPoint.Port = templateEndPoint.Port;
                updatedEndPoint.EndPointType =
                    repository.FindById<EndPointType>(templateEndPoint.EndPointType.Id);
                updatedEndPoint.RequestContentsType =
                   repository.FindById<RequestContentsType>(templateEndPoint.RequestContentsType.Id);
            }
        }

        private void _btnEditEndPoint_Click(object sender, EventArgs e)
        {
            var currentEndPoint = _endPointBinding.Current as EndPointGridRow;
            if (currentEndPoint == null)
            {
                MessageBox.Show($"Выберите конечную точку.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var form = 
                new FormEndPoint(_unitOfWorkFactory, currentEndPoint);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _endPointBinding.ResetBindings(false);
            }
        }

        private void _btnAddEndPoint_Click(object sender, EventArgs e)
        {
            var form = 
                new FormEndPoint(_unitOfWorkFactory, (List<EndPointGridRow>)_endPointBinding.DataSource);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _endPointBinding.MoveLast();
                _endPointBinding.ResetBindings(false);
            }
        }

        private void btnDeleteEndPoint_Click(object sender, EventArgs e)
        {
            var currentEndPoint = _endPointBinding.Current as EndPointGridRow;
            if (currentEndPoint == null)
            {
                MessageBox.Show($"Выберите конечную точку.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show($"Вы уверены, что хотите удалить конечную точку '{currentEndPoint.Name}'?",
                    Application.ProductName, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                return;
            }

            if (currentEndPoint.RowStatus != EndPointGridRowStatus.Added)
            {
                if (_deletedRows.Where(p => p.Id == currentEndPoint.Id).FirstOrDefault() == null)
                {
                    _deletedRows.Add(currentEndPoint);
                }
            }
            
            _endPointBinding.Remove(currentEndPoint);
            _endPointBinding.ResetBindings(false);
        }

        private bool CheckFieldsValue()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_txtSequnceNumber.Text.Trim()))
                {
                    throw new Exception("Заполните поле ввода 'Порядок'.");
                }

                if (string.IsNullOrWhiteSpace(_txtServiceName.Text.Trim()))
                {
                    throw new Exception("Заполните поле ввода 'Название'.");
                }

                try
                {
                    var test = Convert.ToInt32(_txtSequnceNumber.Text);
                }
                catch
                {
                    throw new Exception("В поле ввода 'Порядок' указаны некорректные значения.");
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

        #region Грид

        private void DgvEndPointsFill()
        {
            // настройки таблицы
            _dgvEndPointsList.Dock = DockStyle.Fill;
            _dgvEndPointsList.AutoGenerateColumns = false;
            _dgvEndPointsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvEndPointsList.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 230, 230);
            _dgvEndPointsList.DefaultCellStyle.SelectionForeColor =
                _dgvEndPointsList.DefaultCellStyle.ForeColor;
            _dgvEndPointsList.MultiSelect = false;
            _dgvEndPointsList.ShowCellToolTips = false;
            _dgvEndPointsList.AllowUserToResizeRows = false;
            _dgvEndPointsList.AllowUserToAddRows = false;
            _dgvEndPointsList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _dgvEndPointsList.RowHeadersVisible = false;

            // настройки строк
            Font font = new Font("Tahoma", 8.25f);
            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle(_dgvEndPointsList.RowsDefaultCellStyle);
            cellStyle.Font = font;
            cellStyle.Padding = new Padding(2, 2, 2, 2);
            _dgvEndPointsList.RowsDefaultCellStyle = cellStyle;

            // настройки заголовков столбцов
            _dgvEndPointsList.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;
 
            // столбцы
            _dgvEndPointsList.Columns.Add("Название", "Название");
            _dgvEndPointsList.Columns["Название"].DataPropertyName = "Name";
            _dgvEndPointsList.Columns["Название"].ReadOnly = true;
            _dgvEndPointsList.Columns["Название"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            _dgvEndPointsList.Columns["Название"].MinimumWidth = 120;
            //
            _dgvEndPointsList.Columns.Add("Сетевое имя", "Сетевое имя");
            _dgvEndPointsList.Columns["Сетевое имя"].DataPropertyName = "NetworkName";
            _dgvEndPointsList.Columns["Сетевое имя"].ReadOnly = true;
            _dgvEndPointsList.Columns["Сетевое имя"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            _dgvEndPointsList.Columns["Сетевое имя"].MinimumWidth = 120;
            //
            _dgvEndPointsList.Columns.Add("Ip", "Ip");
            _dgvEndPointsList.Columns["Ip"].DataPropertyName = "Ip";
            _dgvEndPointsList.Columns["Ip"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            _dgvEndPointsList.Columns["Ip"].ReadOnly = true;
            _dgvEndPointsList.Columns["Ip"].Resizable = DataGridViewTriState.False;
            //
            _dgvEndPointsList.Columns.Add("Порт", "Порт");
            _dgvEndPointsList.Columns["Порт"].DataPropertyName = "Port";
            _dgvEndPointsList.Columns["Порт"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            _dgvEndPointsList.Columns["Порт"].ReadOnly = true;
            _dgvEndPointsList.Columns["Порт"].Resizable = DataGridViewTriState.False;
            //
            _dgvEndPointsList.Columns.Add("Тип монитора", "Тип монитора");
            _dgvEndPointsList.Columns["Тип монитора"].DataPropertyName = "EndPointType";
            _dgvEndPointsList.Columns["Тип монитора"].ReadOnly = true;
            _dgvEndPointsList.Columns["Тип монитора"].Resizable = DataGridViewTriState.False;
            _dgvEndPointsList.Columns["Тип монитора"].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            //
            _dgvEndPointsList.Columns.Add("Тип запроса", "Тип запроса");
            _dgvEndPointsList.Columns["Тип запроса"].DataPropertyName = "RequestContentsType";
            _dgvEndPointsList.Columns["Тип запроса"].ReadOnly = true;
            _dgvEndPointsList.Columns["Тип запроса"].Resizable = DataGridViewTriState.False;
            _dgvEndPointsList.Columns["Тип запроса"].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            //
            _dgvEndPointsList.Columns.Add("Состояние", "Состояние");
            _dgvEndPointsList.Columns["Состояние"].ReadOnly = true;
            _dgvEndPointsList.Columns["Состояние"].DataPropertyName = "RowStatus";
            _dgvEndPointsList.Columns["Состояние"].Resizable = DataGridViewTriState.False;
            _dgvEndPointsList.Columns["Состояние"].AutoSizeMode =
              DataGridViewAutoSizeColumnMode.AllCells;
            _dgvEndPointsList.Columns["Состояние"].Visible = false;

            _dgvEndPointsList.CellFormatting += _dgvEndPointsList_CellFormatting;
        }

        private void _dgvEndPointsList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dgvEndPointsList.Columns[e.ColumnIndex].Name == "Тип монитора")
            {
                var val = (EndPointType)e.Value;
                e.Value = val.Description;
            }
            else if (_dgvEndPointsList.Columns[e.ColumnIndex].Name == "Тип запроса")
            {
                var val = (RequestContentsType)e.Value ;
                e.Value = val.Description;
            }
        }

        #endregion

        
    }
}
