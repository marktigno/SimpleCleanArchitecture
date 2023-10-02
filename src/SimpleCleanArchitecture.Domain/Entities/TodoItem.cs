namespace SimpleCleanArchitecture.Domain.Entities;

public class TodoItem
{
    public Guid Id { get; set; }
    public string TodoEntry { get; set; } = string.Empty;
    public DateTime DateTimeCreated { get; set; }
    public DateTime? DateTimeModified { get; set; } = null;
}