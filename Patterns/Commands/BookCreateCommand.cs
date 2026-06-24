namespace E_Library.Patterns.Command
{
    public record BookCreateCommand
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string ISBN { get; init; }
    }
}
