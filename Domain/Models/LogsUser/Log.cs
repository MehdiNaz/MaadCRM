namespace Domain.Models.LogsUser;

public class Log : BaseEntity
{
    public Log()
    {
        Id = Ulid.NewUlid();
    }

    public Ulid Id { get; set; }
    public Ulid? PeyGiryId { get; set; }
    public Ulid? NoteId { get; set; }
    public Ulid? FeedBackId { get; set; }
    public Ulid? CustomerId { get; set; }
    public Ulid? ProductId { get; set; }
    public Ulid? ProductCategoryId { get; set; }
    public Ulid? ForooshId { get; set; }
    public required LogTypes Type { get; set; }
    public required string UserId { get; set; }
    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }
    public string? Description { get; set; }

    public CustomerPeyGiry? PeyGiry { get; set; }
    public CustomerNote? Note { get; set; }
    public CustomerFeedback? Feedback { get; set; }
    public Customer? Customer { get; set; }
    public Product? Product { get; set; }
    public ProductCategory? ProductCategory { get; set; }
    public ForooshFactor? ForooshFactor { get; set; }
    public User? User { get; set; }
}