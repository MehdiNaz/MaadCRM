namespace Application.Services.LogsUserService.Commands;

public struct UpdateLogCommand : IRequest<Result<LogResponse>>
{
    public Ulid? Id { get; set; }
    public Ulid? PeyGiryId { get; set; }
    public Ulid? NoteId { get; set; }
    public Ulid? FeedBackId { get; set; }
    public Ulid? CustomerId { get; set; }
    public Ulid? ProductId { get; set; }
    public Ulid? ProductCategoryId { get; set; }
    public Ulid? ForooshId { get; set; }
    public LogTypes Type { get; set; }
    public string UserId { get; set; }
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public string? Description { get; set; }
}