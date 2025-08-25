namespace ToDoList.src
{
    class Program
    {
        private static DbController dbController = new DbController("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=3160");

        static void Main(string[] args)
        {

        }

        private static void PrintToDoInfo(long id)
        {
            var result = dbController.GetToDoById("notes", id);
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