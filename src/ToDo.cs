namespace ToDoList.src
{
    public class Note
    {
        public long Id { get; }
        public string Title { get; }
        public string? Description { get; }
        public string? Author { get; }

        public Note(long id, string title, string? description, string? author)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
        }
    }
}