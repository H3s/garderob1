using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

namespace garderob1
{
    internal class Database
    {
        private string connectionString = "Server=localhost;Database=parking_1;Uid=root;Pwd=root;";

        public string Login(string phone, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Приводим номер к тому же формату, что и при регистрации
                string dbPhone = new string(phone.Where(char.IsDigit).ToArray());
                if (dbPhone.Length == 11 && dbPhone.StartsWith("8"))
                    dbPhone = "7" + dbPhone.Substring(1);
                else if (dbPhone.Length == 10)
                    dbPhone = "7" + dbPhone;

                string query = "SELECT password, role FROM users WHERE phone = @phone";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@phone", dbPhone);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader.GetString("password");
                        if (PasswordHasher.VerifyPassword(password, storedHash))
                        {
                            return reader.GetString("role");
                        }
                    }
                }
                return null;
            }
        }

        public bool Register(string phone, string password, string fullName, string group)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Преобразуем номер к единому формату (только цифры, начинается с 7)
                    string dbPhone = new string(phone.Where(char.IsDigit).ToArray());
                    if (dbPhone.Length == 11 && dbPhone.StartsWith("8"))
                        dbPhone = "7" + dbPhone.Substring(1);
                    else if (dbPhone.Length == 10)
                        dbPhone = "7" + dbPhone;

                    // Проверяем, существует ли уже такой номер
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE phone = @phone";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@phone", dbPhone);

                    if ((long)checkCommand.ExecuteScalar() > 0)
                        return false;

                    // Если номера нет в базе, регистрируем
                    string insertQuery = "INSERT INTO users (phone, password, full_name, group_name, role) " +
                                        "VALUES (@phone, @password, @fullName, @group, 'user')";

                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@phone", dbPhone);
                    command.Parameters.AddWithValue("@password", PasswordHasher.HashPassword(password));
                    command.Parameters.AddWithValue("@fullName", fullName);
                    command.Parameters.AddWithValue("@group", group);

                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Ошибка регистрации: " + ex.Message);
                return false;
            }
        }

        public bool SetupTickets(int count)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Очищаем старые номерки
                    var clearCmd = new MySqlCommand("DELETE FROM number_tickets", connection);
                    clearCmd.ExecuteNonQuery();

                    // Добавляем новые
                    for (int i = 1; i <= count; i++)
                    {
                        var insertCmd = new MySqlCommand(
                            "INSERT INTO number_tickets (ticket_number) VALUES (@num)",
                            connection);
                        insertCmd.Parameters.AddWithValue("@num", i);
                        insertCmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch { return false; }
        }

        private string FormatPhone(string phone)
        {
            // Удаляем все нецифровые символы
            string digits = new string(phone.Where(char.IsDigit).ToArray());

            // Приводим к формату 7XXXXXXXXXX
            if (digits.Length == 11 && digits.StartsWith("8"))
                return "7" + digits.Substring(1);
            if (digits.Length == 10)
                return "7" + digits;

            return digits;
        }

        // Для пользователя - взять номерок
        public int? TakeTicket(string phone)
        {
            string formattedPhone = FormatPhone(phone);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Находим первый свободный номерок
                var cmd = new MySqlCommand(
                    "UPDATE number_tickets SET user_phone = @phone, taken_at = NOW() " +
                    "WHERE user_phone IS NULL LIMIT 1; " +
                    "SELECT ticket_number FROM number_tickets WHERE user_phone = @phone",
                    connection);
                cmd.Parameters.AddWithValue("@phone", formattedPhone);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }

        public bool ReturnTicket(string phone)
        {
            string formattedPhone = FormatPhone(phone);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(
                    "UPDATE number_tickets SET user_phone = NULL, returned_at = NOW() " +
                    "WHERE user_phone = @phone",
                    connection);
                cmd.Parameters.AddWithValue("@phone", formattedPhone);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int? GetUserTicket(string phone)
        {
            string formattedPhone = FormatPhone(phone);

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var cmd = new MySqlCommand(
                    "SELECT ticket_number FROM number_tickets WHERE user_phone = @phone",
                    connection);
                cmd.Parameters.AddWithValue("@phone", formattedPhone);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }
        // Для админа - просмотр всех номерков
        public DataTable GetAllTickets()
        {
            var table = new DataTable();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new MySqlDataAdapter(
                    "SELECT t.ticket_number, u.full_name, u.phone, t.taken_at " +
                    "FROM number_tickets t LEFT JOIN users u ON t.user_phone = u.phone",
                    connection);
                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetAllRequests()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new MySqlDataAdapter("SELECT * FROM requests", connection);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetActiveRequests()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new MySqlDataAdapter("SELECT * FROM requests WHERE status = 'Активный'", connection);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public bool AddRequest(string userId, string title, string description)
        {
            try
            {
                // Проверка на корректность данных
                if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
                {
                    return false;
                }

                // Создание запроса
                string query = "INSERT INTO requests (user_id, title, description, status) VALUES (@userId, @title, @description, 'Активный')";

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@description", description);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Если строк было затронуто больше 0, значит заявка добавлена
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки (можно вывести в консоль, записать в лог-файл или MessageBox)
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка добавления заявки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public bool UpdateRequestStatus(int requestId, string newStatus)
        {
            // Возможные статусы
            string[] validStatuses = { "Активный", "Решённый", "Ошибка" };

            // Убираем пробелы и проверяем допустимость значения
            newStatus = newStatus.Trim();
            MessageBox.Show($"Полученный статус: [{newStatus}]", "Отладка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (newStatus == "Завершен") newStatus = "Решённый"; // Или другой статус из базы
            if (newStatus == "Отменен") newStatus = "Ошибка"; // Или другой статус из базы
            if (newStatus == "Отменен") newStatus = "Ошибка";

            if (!validStatuses.Contains(newStatus))
            {
                MessageBox.Show($"Недопустимый статус: {newStatus}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new MySqlCommand(
                    "UPDATE requests SET status = @status WHERE id = @requestId",
                    connection);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@requestId", requestId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public int? GetUserIdByPhone(string phone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT id FROM users WHERE phone = @phone";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@phone", phone);

                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : (int?)null;
            }
        }


    }
}
