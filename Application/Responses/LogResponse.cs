namespace Application.Responses;

public struct LogResponse
{
    public Ulid Id { get; set; }
    public Ulid? PeyGiryId { get; set; }
    public string PeyGiryDescription { get; set; }
    public Ulid? NoteId { get; set; }
    public string NoteDescription { get; set; }
    public Ulid? FeedBackId { get; set; }
    public string? FeedBackDescription { get; set; }
    public Ulid? CustomerId { get; set; }
    public string CustomerFullName { get; set; }
    public Ulid? ProductId { get; set; }
    public string ProductName { get; set; }
    public Ulid? ProductCategoryId { get; set; }
    public string ProductCategoryName { get; set; }
    public Ulid? ForooshId { get; set; }
    public LogTypes Type { get; set; }
    public string UserId { get; set; }
    public string UserFullName { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string? Description { get; set; }
}