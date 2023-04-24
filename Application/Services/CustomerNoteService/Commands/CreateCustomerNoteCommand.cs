namespace Application.Services.CustomerNoteService.Commands;

public struct CreateCustomerNoteCommand : IRequest<Result<CustomerNote>>
{
    public string Description { get; set; }
    public Ulid? ProductId { get; set; }
    public ICollection<Ulid>? HashTagIds { get; set; }
    public Ulid CustomerId { get; set; }
    public string? IdUser { get; set; }
    //public File AttachmentFile { get; set; }
}