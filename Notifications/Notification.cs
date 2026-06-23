namespace E_Library.Notifications
{
    public record Notification
    {
        int UserId { get; init; }
        int BookId { get; init; }
        string UserName { get; init; }
        string BookTitle { get; init; }
        DateTime NotifiedOn {  get; init; } = DateTime.Now;
    }
}
