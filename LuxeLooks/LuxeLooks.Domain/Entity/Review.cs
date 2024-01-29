namespace LuxeLooks.Domain.Entity;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public DateTime CreateDate { get; set; }
    public Guid ProductId { get; set; }
}