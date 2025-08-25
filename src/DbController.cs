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
                command.CommandText = $@"
                INSERT INTO {table} (title, description, author)
                VALUES (@title, @description, @author);";
                command.Parameters.AddWithValue("table", table);
                command.Parameters.AddWithValue("title", title);
                command.Parameters.AddWithValue("description", description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("author", author ?? (object)DBNull.Value);

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
                command.CommandText = $@"
                TRUNCATE TABLE {table} RESTART IDENTITY;";
                command.Parameters.AddWithValue("table", table);
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


        public Note? GetToDoById(string table, long id)
        {
            try
            {
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = $@"
                SELECT id, title, description, author FROM {table}
                WHERE id = @id";
                command.Parameters.AddWithValue("@table", table);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var title = reader.GetString(1);
                        string? description;
                        string? author;
                        if (reader.IsDBNull(2)) description = null; else description = reader.GetString(2);
                        if (reader.IsDBNull(3)) author = null; else author = reader.GetString(3);
                        return new Note(
                            id,
                            title,
                            description,
                            author);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Такого id несуществует");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении задачи по id={id}: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
            return null;
        }
    }
}