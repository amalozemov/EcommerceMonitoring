using ECMonitoring.Data;
using ECMonitoring.Data.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECMonitoring.Service.Forms
{
    public partial class FormServicesList : Form
    {
        private IUnitOfWorkFactory _unitOfWorkFactory { get; set; }
        BindingSource _dataBinding { get; set; }

        public FormServicesList(IUnitOfWorkFactory unitOfWorkFactory)
        {
            InitializeComponent();

            _unitOfWorkFactory = unitOfWorkFactory;
            _dataBinding = new BindingSource();

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var services = repository.GetEntities<Data.Service>().ToList();
                
                DgvServicesFill();

                _dataBinding.DataSource = services;
                _dgvServices.DataSource = _dataBinding;
            }
        }

        private void DgvServicesFill()
        {
            // настройки таблицы
            _dgvServices.Dock = DockStyle.Fill;
            _dgvServices.AutoGenerateColumns = false;
            _dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvServices.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 230, 230);
            _dgvServices.DefaultCellStyle.SelectionForeColor =
                _dgvServices.DefaultCellStyle.ForeColor;
            _dgvServices.MultiSelect = false;
            _dgvServices.ShowCellToolTips = false;
            _dgvServices.AllowUserToResizeRows = false;
            _dgvServices.AllowUserToAddRows = false;
            _dgvServices.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _dgvServices.RowHeadersVisible = false;

            // настройки строк
            Font font = new Font("Tahoma", 8.25f);
            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle(_dgvServices.RowsDefaultCellStyle);
            cellStyle.Font = font;
            cellStyle.Padding = new Padding(2, 2, 2, 2);
            _dgvServices.RowsDefaultCellStyle = cellStyle;

            // настройки заголовков столбцов
            _dgvServices.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // столбцы
            _dgvServices.Columns.Add("Название", "Название");
            _dgvServices.Columns["Название"].DataPropertyName = "Name";
            _dgvServices.Columns["Название"].ReadOnly = true;
            _dgvServices.Columns["Название"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            _dgvServices.Columns["Название"].MinimumWidth = 120;
            //
            _dgvServices.Columns.Add("Порядок", "Порядок");
            _dgvServices.Columns["Порядок"].DataPropertyName = "SequenceNumber";
            _dgvServices.Columns["Порядок"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            _dgvServices.Columns["Порядок"].ReadOnly = true;
            _dgvServices.Columns["Порядок"].MinimumWidth = 70;
        }

        private void _btnServiceEdit_Click(object sender, EventArgs e)
        {
            var form = 
                new FormService(_unitOfWorkFactory, (Data.Service)_dataBinding.Current);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _dataBinding.ResetBindings(false);
            }
        }

        private void _btnServiceCreate_Click(object sender, EventArgs e)
        {
            var form =
                new FormService(_unitOfWorkFactory, (List<Data.Service>)_dataBinding.DataSource);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _dataBinding.MoveLast();
                _dataBinding.ResetBindings(false);
            }
        }

        private void _btnRemoveService_Click(object sender, EventArgs e)
        {
            var currentService = _dataBinding.Current as Data.Service;
            if (currentService == null)
            {
                MessageBox.Show($"Выберите сервис.",
                    Application.ProductName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var res = MessageBox.Show($"Вы уверены, что хотите удалить сервис '{currentService.Name}' и все его конечные точки?",
                Application.ProductName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                return;
            }
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var endPoints = repository.GetEntities<EndPoint>().Where(p => p.ServiceId == currentService.Id);
                foreach (var endPoint in endPoints)
                {
                    repository.Delete(endPoint);
                }

                var service = repository.FindById<Data.Service>(currentService.Id);
                repository.Delete(service);

                uow.Commit();
            }

            _dataBinding.Remove(currentService);
            _dataBinding.ResetBindings(false);
        }
    }
}
