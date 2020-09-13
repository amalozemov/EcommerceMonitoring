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
        BindingSource _endPointBinding { get; set; }
        IUnitOfWorkFactory _unitOfWorkFactory;

        public FormService()
        {
            InitializeComponent();

            DgvEndPointsFill();
        }

        public FormService(IUnitOfWorkFactory unitOfWorkFactory) : this()
        {
            Text = "Создание сервиса";
            _unitOfWorkFactory = unitOfWorkFactory;
            //_service = new Data.Service();
            _endPointBinding = new BindingSource();
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
                    repository.GetEntities<EndPoint>().Where(e => e.ServiceId == _service?.Id).ToList();
                _dgvEndPointsList.DataSource = _endPointBinding;
            }
        }

        private void _btnApplay_Click(object sender, EventArgs e)
        {
            if (!CheckFieldsValue())
            {
                return;
            }

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var service = repository.FindById<Data.Service>(_service.Id);

                _service.SequenceNumber = Convert.ToInt32(_txtSequnceNumber.Text);
                _service.Name = _txtServiceName.Text;

                service.SequenceNumber = _service.SequenceNumber;
                service.Name = _service.Name;

                uow.Commit();
            }

            DialogResult = DialogResult.OK;
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

                if (_dgvEndPointsList.Rows.Count == 0)
                {
                    throw new Exception("Добавьте хотя бы одну конечную точку.");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                       Application.ProductName, MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #region

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
            cellStyle.Padding = new Padding(2, 0, 2, 0);
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
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dgvEndPointsList.Columns["Ip"].ReadOnly = true;
            _dgvEndPointsList.Columns["Ip"].MinimumWidth = 120;
            //
            _dgvEndPointsList.Columns.Add("Порт", "Порт");
            _dgvEndPointsList.Columns["Порт"].DataPropertyName = "Port";
            _dgvEndPointsList.Columns["Порт"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dgvEndPointsList.Columns["Порт"].ReadOnly = true;
            _dgvEndPointsList.Columns["Порт"].MinimumWidth = 120;

            // тут 13.09.2020 
            //1) привязывать столбцы-списки (смотри проекты CallCounter и Архивариус)
            //2) Конечные точки - изменение
            //3) Добавление и Удаление всех итемов

        }

        #endregion
    }
}
