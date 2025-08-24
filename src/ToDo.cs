namespace ToDoList.src
{
    public class ToDo
    {
        public Int64 Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public string? Author { get; }

        public ToDo(Int64 id, string title, string? description, string? author)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
        }
    }
}