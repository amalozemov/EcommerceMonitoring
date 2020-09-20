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
    public partial class FormUsers : Form
    {
        IUnitOfWorkFactory _unitOfWorkFactory;
        BindingSource _dataBinding;

        public FormUsers(IUnitOfWorkFactory unitOfWorkFactory)
        {
            InitializeComponent();
            _unitOfWorkFactory = unitOfWorkFactory;
            DgvUsersFill();
            _dataBinding = new BindingSource();

            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var users = repository.GetEntities<User>().ToList();

                _dataBinding.DataSource = users;
                _dgvUsers.DataSource = _dataBinding;
            }
        }

        private void DgvUsersFill()
        {
            // настройки таблицы
            _dgvUsers.Dock = DockStyle.Fill;
            _dgvUsers.AutoGenerateColumns = false;
            _dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dgvUsers.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(230, 230, 230);
            _dgvUsers.DefaultCellStyle.SelectionForeColor =
                _dgvUsers.DefaultCellStyle.ForeColor;
            _dgvUsers.MultiSelect = false;
            _dgvUsers.ShowCellToolTips = false;
            _dgvUsers.AllowUserToResizeRows = false;
            _dgvUsers.AllowUserToAddRows = false;
            _dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            _dgvUsers.RowHeadersVisible = false;

            // настройки строк
            Font font = new Font("Tahoma", 8.25f);
            DataGridViewCellStyle cellStyle =
                new DataGridViewCellStyle(_dgvUsers.RowsDefaultCellStyle);
            cellStyle.Font = font;
            cellStyle.Padding = new Padding(2, 2, 2, 2);
            _dgvUsers.RowsDefaultCellStyle = cellStyle;

            // настройки заголовков столбцов
            _dgvUsers.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            // столбцы
            _dgvUsers.Columns.Add("Имя пользователя", "Имя пользователя");
            _dgvUsers.Columns["Имя пользователя"].DataPropertyName = "Login";
            _dgvUsers.Columns["Имя пользователя"].ReadOnly = true;
            _dgvUsers.Columns["Имя пользователя"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            _dgvUsers.Columns["Имя пользователя"].MinimumWidth = 120;
        }

        private void btnUserCreate_Click(object sender, EventArgs e)
        {
            var form =
                new FormUser(_unitOfWorkFactory, (List<User>)_dataBinding.DataSource);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _dataBinding.MoveLast();
                _dataBinding.ResetBindings(false);
            }
        }

        private void btnUserEdit_Click(object sender, EventArgs e)
        {
            var form =
                new FormUser(_unitOfWorkFactory, (User)_dataBinding.Current);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _dataBinding.ResetBindings(false);
            }
        }

        private void btnUserChangePassword_Click(object sender, EventArgs e)
        {
            var form =
                new FormUser(_unitOfWorkFactory, (User)_dataBinding.Current, true);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                _dataBinding.ResetBindings(false);
            }
        }
    }
}
