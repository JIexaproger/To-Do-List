using Microsoft.Data.Sqlite;
using ToDoList.src;

namespace App.src
{
    public class DbController
    {
        private SqliteConnection _connection;

        public DbController(string dbPath)
        {
            _connection = new SqliteConnection("Data Source=" + dbPath);

        }

        public void Connect()
        {
            _connection.Open();
        }

        public void Disconnect()
        {
            _connection.Close();
        }

        public void Add(string title, string? description, string? author)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Users (title, description, author)
                VALUES ($title, $description, $author)";

            command.Parameters.AddWithValue("$title", title);
            command.Parameters.AddWithValue("$description", description);
            command.Parameters.AddWithValue("$author", author);

            command.ExecuteNonQuery();
        }

        public ToDo? GetToDo(Int64 toDoId)
        {
            using var command = _connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Age FROM Users";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string title = reader.GetString(1);
                string? description = reader.GetString(1);
                string? author = reader.GetString(1);
                return new ToDo(id, title, description, author);
            }
            return null;
        }
    }
}