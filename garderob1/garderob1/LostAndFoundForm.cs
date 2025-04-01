using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class LostAndFoundForm : Form
    {
        private string userPhone;
        private bool isAdmin;
        private Database database = new Database();

        public LostAndFoundForm(string userPhone)
        {
            InitializeComponent();
            this.userPhone = userPhone;
            this.isAdmin = string.IsNullOrEmpty(userPhone);
            SetupUI();
            LoadRequests();
        }

        private void SetupUI()
        {
            this.Text = isAdmin ? "Бюро находок (Администратор)" : "Бюро находок (Пользователь)";
            btnChangeStatus.Visible = isAdmin; // Только администратор может менять статус
            btnAddRequest.Visible = !isAdmin; // Пользователь может только добавить заявку
            cmbStatus.Visible = isAdmin; // Скрываем ComboBox для пользователя
            lblStatus.Visible = isAdmin; // Скрываем метку "Статус" для пользователя
        }


        private void LoadRequests()
        {
            DataTable dt = isAdmin ? database.GetAllRequests() : database.GetActiveRequests();
            dataGridViewRequests.DataSource = dt;
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            // Приводим номер телефона к формату без символов
            string cleanPhone = new string(userPhone.Where(char.IsDigit).ToArray());

            // Проверка, если телефон пользователя задан
            if (string.IsNullOrEmpty(cleanPhone))
            {
                MessageBox.Show("Пользователь не найден, или не указан номер телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Заполните все поля для добавления заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем userId по номеру телефона пользователя
            int? userId = database.GetUserIdByPhone(cleanPhone);

            if (userId == null)
            {
                MessageBox.Show("Пользователь с таким номером телефона не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Преобразуем userId в строку
            string userIdString = userId.Value.ToString();

            // Попытка добавить заявку с userId
            bool isAdded = database.AddRequest(userIdString, txtTitle.Text, txtDescription.Text);

            if (isAdded)
            {
                MessageBox.Show("Заявка добавлена успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequests(); // Перезагружаем список заявок
            }
            else
            {
                MessageBox.Show("Произошла ошибка при добавлении заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["id"].Value);
                string newStatus = cmbStatus.SelectedItem.ToString();
                database.UpdateRequestStatus(requestId, newStatus);
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку для изменения статуса.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
