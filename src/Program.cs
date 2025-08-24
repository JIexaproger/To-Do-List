using System.IO.Compression;
using System.Threading.Tasks;

namespace ToDoList.src
{
    class Program
    {
        private static DbController dbController = new DbController("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=3160");

        static async Task Main(string[] args)
        {
            // dbController.Clear();

            // dbController.Add("Hello", null, "VS Code");
            // dbController.Add("World!", "second part ' // commit ", "author24");
            // dbController.Add("empty", null, "JIEXA");
            // dbController.Add("lol", "null", "JIEXA");

            // for (int i = 1; i < 5; i++)
            // {
            //     await PrintToDoInfo(i);
            // }
        }

        // private static async Task PrintToDoInfo(long id)
        // {
        //     var result = (await dbController.GetToDoAsync(id))[0];
        //     if (result == null)
        //     {
        //         Console.WriteLine($"Заметка с ID {id} не найдена");
        //     }
        //     else
        //     {
        //         Console.WriteLine($"ID: {result.Id}, Title: {result.Title}, Description: {result.Description ?? "Description is null"}, Author: {result.Author ?? "Author is anonymous"}");
        //     }
        // }
    }
}