namespace Application.Services.CustomerNoteService.Commands;

public struct CreateCustomerNoteCommand : IRequest<CustomerNoteResponse?>
{
    public Ulid ProductId { get; set; }
    public string Description { get; set; }
    public Status CustomerNoteStatus { get; set; }
    public ICollection<string> HashTagIds { get; set; }
    //public File AttachmentFile { get; set; }
    public Ulid CustomerId { get; set; }
}