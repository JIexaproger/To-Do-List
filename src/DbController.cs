using System.Threading.Tasks;
using Npgsql;

namespace ToDoList.src
{
    public class DbController
    {
        private string _connectionString;
        private NpgsqlConnection _connection;

        public DbController(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new NpgsqlConnection(_connectionString);

        }


        public void Add(string table, string title, string? description = null, string? author = null)
        {
            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = @"
                INSERT INTO @table (title, description, author)
                VALUES (@title, @description, @author);";
                command.Parameters.AddWithValue("@table", table);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@author", author ?? (object)DBNull.Value);

                command.ExecuteNonQuery();
                Console.WriteLine($"Строка успешно добавлена. {title}, {description}, {author}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при добавлении: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Clear(string table)
        {
            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = @"
                TRUNCATE TABLE @table RESTART IDENTITY;";
                command.Parameters.AddWithValue("@table", table);
                command.ExecuteNonQuery();
                Console.WriteLine("Отчистка успешно заверешна");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отчистке: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }


        public ToDo[] GetToDo(long todo_Id)
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении задачи по id={todo_Id}: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}