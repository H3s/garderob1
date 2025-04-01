using Microsoft.VisualBasic.ApplicationServices;
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

namespace garderob1
{

    public partial class LoginForm : Form
    {
        private Database db = new Database();
        private Regex phoneRegex = new Regex(@"^(\+7|8)[\(\s-]*\d{3}[\)\s-]*\d{3}[\s-]*\d{2}[\s-]*\d{2}$");
        private Regex nameRegex = new Regex(@"^[А-ЯЁа-яё\s-]+$");
        private ErrorProvider errorProvider1 = new ErrorProvider();



        public LoginForm()
        {
            InitializeComponent();
            
            // В конструкторе каждой формы (LoginForm, UserForm, AdminForm)
            this.Font = new Font("Segoe UI", 10); // Читаемый шрифт
            this.BackColor = Color.FromArgb(245, 245, 245); // Светло-серый фон
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Фиксированный размер
            this.MaximizeBox = false; // Убрать кнопку максимизации
            txtPhone.Validating += (s, e) => {
                if (txtPhone.Text.Contains("_"))
                {
                    errorProvider1.SetError(txtPhone, "Введите номер полностью");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(txtPhone, "");
                }
            };
            ShowLoginFields();
            
        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string password = txtPassword.Text;

            if (!ValidatePhone(phone))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7(999)999-99-99", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role = db.Login(phone, password);

            if (role != null)
            {
                MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (role == "admin")
                {
                    AdminForm adminForm = new AdminForm(phone); 
                    adminForm.Show();
                }
                else
                {
                    UserForm userForm = new UserForm(phone);
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка входа! Проверьте номер телефона и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text;
            string password = txtPassword.Text;
            string fullName = txtFullName.Text;
            string group = txtGroup.Text;
            string dbPhone = new string(phone.Where(char.IsDigit).ToArray());

            if (txtPhone.Text.Contains("_"))
            {
                MessageBox.Show("Введите номер телефона полностью", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePassword(password))
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов, включая цифры и заглавные буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidatePhone(phone))
            {
                MessageBox.Show("Номер телефона должен быть в формате +7(999)999-99-99", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateName(fullName))
            {
                MessageBox.Show("ФИО должно содержать только кириллические буквы, пробелы и дефисы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (db.Register(dbPhone, password, fullName, group))
            {
                MessageBox.Show("Регистрация успешна! Теперь войдите в систему.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtGroup.Text = "";
                ShowLoginFields();
            }
            else
            {
                MessageBox.Show("Ошибка регистрации! Номер телефона уже используется.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidatePhone(string phone)
        {
            // Проверяем, что маска заполнена
            if (phone.Contains("_")) return false;

            // Извлекаем только цифры
            string digits = new string(phone.Where(char.IsDigit).ToArray());

            // Проверяем длину (11 цифр с кодом страны или 10 без)
            return digits.Length == 11 && (digits.StartsWith("7") || digits.StartsWith("8")) ||
                   digits.Length == 10;
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            string phone = txtPhone.Text;

            // Проверяем, заполнена ли маска полностью
            if (phone.Contains("_"))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Введите номер телефона полностью");
                return;
            }

            errorProvider1.SetError(txtPhone, "");
        }

        private bool ValidateName(string name)
        {
            return nameRegex.IsMatch(name) && name.Length >= 5;
        }
        private bool ValidatePassword(string password)
        {
            if (password.Length < 8)
                return false;
            if (!password.Any(char.IsDigit))
                return false;
            if (!password.Any(char.IsUpper))
                return false;
            return true;
        }
        private void ShowLoginFields()
        {
            // Скрываем регистрационные поля
            btnLogin.Visible = true;
            linkRegister.Visible = true;

            // Скрываем поля регистрации
            lblFullName.Visible = false;
            txtFullName.Visible = false;
            lblGroup.Visible = false;
            txtGroup.Visible = false;
            btnRegister.Visible = false;
            linkBackToLogin.Visible = false;

            // Восстанавливаем размер формы
            this.ClientSize = new Size(360, 206);
        }

        private void ShowRegisterFields()
        {
            // Показываем все дополнительные поля
            lblFullName.Visible = true;
            txtFullName.Visible = true;
            lblGroup.Visible = true;
            txtGroup.Visible = true;
            btnRegister.Visible = true;
            linkBackToLogin.Visible = true;
            
            // Скрываем элементы входа
            btnLogin.Visible = false;
            linkRegister.Visible = false;
            
            // Увеличиваем форму
            this.ClientSize = new Size(360, 306);
        }


        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRegisterFields();
        }

        private void linkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowLoginFields();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Инициализация формы при загрузке
            ShowLoginFields(); // Показываем поля для входа при запуске
            this.ActiveControl = txtPhone; // Устанавливаем фокус на поле телефона
        }
    }
}
