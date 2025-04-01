using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garderob1
{
    public partial class UserForm : Form
    {
        private Database db = new Database();
        private string userPhone;
        private int? currentTicket = null;

        public UserForm(string phone)
        {
            InitializeComponent();

            this.Font = new Font("Segoe UI", 10); // Читаемый шрифт
            this.BackColor = Color.FromArgb(245, 245, 245); // Светло-серый фон
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Фиксированный размер
            this.MaximizeBox = false; // Убрать кнопку максимизации

            userPhone = phone;

            // Проверяем, есть ли у пользователя активный номерок
            currentTicket = db.GetUserTicket(userPhone);
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            // Если есть активный номерок
            if (currentTicket.HasValue)
            {
                lblTicket.Text = $"Ваш номерок: {currentTicket.Value}";
                btnTakeTicket.Visible = false;  // Делаем недоступной
                btnReturnTicket.Visible = true; // Делаем доступной
            }
            else
            {
                lblTicket.Text = "Номерок не получен";
                btnTakeTicket.Visible = true;
                btnReturnTicket.Visible = false;
            }
        }

        private void btnTakeTicket_Click(object sender, EventArgs e)
        {
            try
            {
                currentTicket = db.TakeTicket(userPhone);

                if (currentTicket.HasValue)
                {
                    MessageBox.Show($"Вы получили номерок {currentTicket.Value}");
                    UpdateButtonStates();
                }
                else
                {
                    MessageBox.Show("Нет свободных номерков");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnReturnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.ReturnTicket(userPhone))
                {
                    MessageBox.Show($"Номерок {currentTicket.Value} возвращен");
                    currentTicket = null;
                    UpdateButtonStates();
                }
                else
                {
                    MessageBox.Show("Не удалось вернуть номерок");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnLostAndFound_Click(object sender, EventArgs e)
        {
            LostAndFoundForm lostAndFoundForm = new LostAndFoundForm(userPhone); // Передаём данные пользователя
            lostAndFoundForm.Show();
        }
    }
}
