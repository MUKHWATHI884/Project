using MySqlConnector;
using System.Collections.Generic;

namespace Project
{
    public class TaskRepository
    {
        // CHANGE THIS to match your MySQL setup
        // If you use XAMPP: User ID=root, Password= (leave empty)
        // If you use MySQL Workbench: use the password you set when you installed MySQL
        private string ConnString = "Server=localhost;Database=chatbot_db;User ID=root;Password=@mukhwathi2004;";

        public TaskRepository()
        {
            // Create DB + Table if they don't exist yet
            using var conn = new MySqlConnection("Server=localhost;User ID=root;Password=@mukhwathi2004;");
            conn.Open();
            using var cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS chatbot_db; USE chatbot_db; CREATE TABLE IF NOT EXISTS Tasks (Id INT AUTO_INCREMENT PRIMARY KEY, Title VARCHAR(200), Description VARCHAR(500), ReminderDate VARCHAR(50), IsCompleted INT DEFAULT 0);", conn);
            cmd.ExecuteNonQuery();
        }

        public void AddTask(TaskItem t)
        {
            using var c = new MySqlConnection(ConnString);
            c.Open();
            using var cmd = new MySqlCommand("INSERT INTO Tasks (Title, Description, ReminderDate) VALUES (@t, @d, @r)", c);
            cmd.Parameters.AddWithValue("@t", t.Title);
            cmd.Parameters.AddWithValue("@d", t.Description ?? "");
            cmd.Parameters.AddWithValue("@r", t.ReminderDate?.ToString("yyyy-MM-dd") ?? "");
            cmd.ExecuteNonQuery();
        }

        public List<TaskItem> GetAllTasks()
        {
            var list = new List<TaskItem>();
            using var c = new MySqlConnection(ConnString);
            c.Open();
            using var cmd = new MySqlCommand("SELECT * FROM Tasks", c);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                list.Add(new TaskItem
                {
                    Id = r.GetInt32(0),
                    Title = r.GetString(1),
                    Description = r.IsDBNull(2) ? "" : r.GetString(2),
                    ReminderDate = System.DateTime.TryParse(r.IsDBNull(3) ? "" : r.GetString(3), out var d) ? d : null,
                    IsCompleted = r.GetInt32(4) == 1
                });
            }
            return list;
        }

        public void DeleteTask(int id)
        {
            using var c = new MySqlConnection(ConnString);
            c.Open();
            using var cmd = new MySqlCommand("DELETE FROM Tasks WHERE Id=@id", c);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void MarkComplete(int id)
        {
            using var c = new MySqlConnection(ConnString);
            c.Open();
            using var cmd = new MySqlCommand("UPDATE Tasks SET IsCompleted=1 WHERE Id=@id", c);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}