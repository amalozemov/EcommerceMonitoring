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
    enum UserEditMode
    {
        Adding,
        EditName,
        EditPass
    }

    public partial class FormUser : Form
    {
        IUnitOfWorkFactory _unitOfWorkFactory;
        User _user;
        List<User> _users;
        UserEditMode _editMode;

        private FormUser(IUnitOfWorkFactory unitOfWorkFactory)
        {
            InitializeComponent();
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public FormUser(IUnitOfWorkFactory unitOfWorkFactory, List<User> users) : this(unitOfWorkFactory)
        {
            Text = "Добавление пользователя";
            _users = users;
            _lblPassword.Visible = false;
            _txtPassword.Visible = false;
            _editMode = UserEditMode.Adding;
        }

        public FormUser(IUnitOfWorkFactory unitOfWorkFactory, User user) : this(unitOfWorkFactory)
        {
            Text = "Изменение пользователя";
            _user = user;
            _lblPassword.Visible = false;
            _txtPassword.Visible = false;
            _lblNewPassword.Visible = false;
            _txtNewPassword.Visible = false;
            _txtName.Text = _user.Login;
            _editMode = UserEditMode.EditName;
        }

        public FormUser(IUnitOfWorkFactory unitOfWorkFactory, User user, bool changePassword) : this(unitOfWorkFactory)
        {
            Text = "Изменение пароля";
            _user = user;
            _lblName.Visible = false;
            _txtName.Visible = false;
            _editMode = UserEditMode.EditPass;
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

                if (_editMode == UserEditMode.Adding)
                {
                    var user = new User()
                    {
                        Login = _txtName.Text.Trim(),
                        Password = _txtNewPassword.Text.Trim()
                    };
                    repository.Add(user);
                    _users.Add(user);
                }
                else if (_editMode == UserEditMode.EditName)
                {
                    var user = repository.FindById<User>(_user.Id);
                    user.Login = _txtName.Text.Trim();
                    _user.Login = user.Login;
                }
                else if (_editMode == UserEditMode.EditPass)
                {
                    var user = repository.FindById<User>(_user.Id);
                    user.Password = _txtNewPassword.Text.Trim();
                    _user.Password = user.Password;
                }

                uow.Commit();
            }

            DialogResult = DialogResult.OK;
        }

        private bool CheckFieldsValue()
        {
            try
            {
                if (_editMode == UserEditMode.Adding)
                {
                    if (_txtName.Text.Trim().Length < 3)
                    {
                        throw new Exception("Поле 'Имя' должно содержать не менее 3-х символов.");
                    }

                    if (_txtName.Text.Trim().Contains(" "))
                    {
                        throw new Exception("Поле 'Имя' не должно содержать пробелов.");
                    }

                    if (_txtNewPassword.Text.Trim().Length < 3)
                    {
                        throw new Exception("Поле 'Новый пароль' должно содержать не менее 3-х символов.");
                    }

                    CheckLogin(_txtName.Text.Trim());
                }
                else if (_editMode == UserEditMode.EditName)
                {
                    if (_txtName.Text.Trim().Length < 3)
                    {
                        throw new Exception("Поле 'Имя' должно содержать не менее 3-х символов.");
                    }

                    if (_txtName.Text.Trim().Contains(" "))
                    {
                        throw new Exception("Поле 'Имя' не должно содержать пробелов.");
                    }

                    CheckLogin(_txtName.Text.Trim());
                }
                else if (_editMode == UserEditMode.EditPass)
                {
                    if (_txtPassword.Text.Trim().Length < 3)
                    {
                        throw new Exception("Поле 'Новый пароль' должно содержать не менее 3-х символов.");
                    }

                    if (_txtNewPassword.Text.Trim().Length < 3)
                    {
                        throw new Exception("Поле 'Новый пароль' должно содержать не менее 3-х символов.");
                    }

                    CheckPassword(_txtPassword.Text.Trim());
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

        private void CheckPassword(string password)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();
                var user = 
                    repository.GetEntities<User>().Where(p => p.Id == _user.Id && p.Password == password.Trim()).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("Неверный пароль.");
                }
            }
        }
        // где то тут 20.09.2020 - 1) ещё раз проверить добаление и изменение пользователей 2) удаление пользователя 3) Проверка авторизации с БД в веб.
        private void CheckLogin(string login)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                var repository = uow.GetRepository();

                if (repository.GetEntities<User>().Where(p => p.Login == login.Trim()).FirstOrDefault() != null)
                {
                    throw new Exception($"Пользователь с логином '{login} уже существует");
                }
            }
        }
    }
}
