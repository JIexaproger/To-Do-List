using System.IO.Compression;
using System.Threading.Tasks;

namespace ToDoList.src
{
    class Program
    {
        private static DbController dbController = new DbController("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=3160");

        static void Main(string[] args)
        {
            dbController.Clear("tasks");

            dbController.Add("tasks", "Hello", "null1", "VS Code");
            dbController.Add("tasks", "World!", "second part ' // commit ", "author24");
            dbController.Add("tasks", "empty", null, "JIEXA");
            dbController.Add("tasks", "lol", "null", "JIEXA");

            for (int i = 1; i < 10; i++)
            {
                PrintToDoInfo(i);
            }
        }

        private static void PrintToDoInfo(long id)
        {
            var result = dbController.GetToDoById("tasks", id);
            if (result == null)
            {
                Console.WriteLine($"Заметка с ID {id} не найдена");
            }
            else
            {
                Console.WriteLine($"ID: {result.Id}, Title: {result.Title}, Description: {result.Description ?? "Description is null"}, Author: {result.Author ?? "Author is anonymous"}");
            }
        }
    }
}