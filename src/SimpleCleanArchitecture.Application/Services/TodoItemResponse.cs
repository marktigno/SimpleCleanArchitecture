namespace SimpleCleanArchitecture.Application.Services;

public class TodoItemResponse
{
    public Guid Id { get; set; }
    public string? TodoEntry { get; set; }
    public DateTime DateTimeCreated { get; set; }
    public DateTime? DateTimeModified { get; set; }
}