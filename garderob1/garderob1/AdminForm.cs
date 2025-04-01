using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace garderob1
{
    public partial class AdminForm : Form
    {
        private Database db = new Database();

        public AdminForm(string adminPhone)
        {
            InitializeComponent();
            ApplyStyles();
            RefreshTickets();
        }

        private void ApplyStyles()
        {
            this.Font = new Font("Segoe UI", 10);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Стилизация DataGridView
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 9);
        }

        private void btnSetupTickets_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTicketCount.Text, out int count) || count <= 0)
            {
                MessageBox.Show("Введите корректное положительное число");
                return;
            }
            if (count > 1000)
            {
                MessageBox.Show("Максимальное количество номерков - 1000");
                return;
            }

            // Получаем список номерков
            var tickets = db.GetAllTickets();

            // Проверяем, есть ли колонка "full_name"
            if (!tickets.Columns.Contains("full_name"))
            {
                MessageBox.Show("Ошибка: данные о занятых номерках отсутствуют. Попробуйте позже.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем, есть ли занятые номерки
            int takenTickets = tickets.AsEnumerable()
                .Count(row => !string.IsNullOrEmpty(row.Field<string>("full_name")));

            if (takenTickets > 0)
            {
                MessageBox.Show("Нельзя изменить количество номерков, пока есть занятые. " +
                              "Дождитесь, пока все номерки будут возвращены.",
                              "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.SetupTickets(count))
            {
                MessageBox.Show($"Установлено {count} номерков");
                RefreshTickets();
            }
            else
            {
                MessageBox.Show("Ошибка при обновлении количества номерков");
            }
        }



        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTickets();
        }

        private void RefreshTickets()
        {
            try
            {
                var tickets = db.GetAllTickets();
                dataGridView1.DataSource = tickets;

                // Проверяем наличие нужных колонок
                if (tickets.Columns.Contains("full_name"))
                {
                    int totalTickets = tickets.Rows.Count;
                    int freeTickets = tickets.AsEnumerable()
                        .Count(row => string.IsNullOrEmpty(row.Field<string>("full_name"))); // Свободны, если full_name пуст

                    lblStats.Text = $"Всего: {totalTickets} | Свободно: {freeTickets} | Занято: {totalTickets - freeTickets}";
                }
                else
                {
                    lblStats.Text = "Ошибка: нет данных о номерках!";
                }

                // Проверяем наличие столбца перед сортировкой
                if (dataGridView1.Columns.Contains("ticket_number"))
                {
                    dataGridView1.Sort(dataGridView1.Columns["ticket_number"], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLostAndFound_Click(object sender, EventArgs e)
        {
            LostAndFoundForm lostAndFoundForm = new LostAndFoundForm(null); // Передаём данные пользователя
            lostAndFoundForm.Show();
        }
    }
}

