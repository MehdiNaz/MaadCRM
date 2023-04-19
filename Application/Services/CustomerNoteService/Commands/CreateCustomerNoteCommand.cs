namespace Application.Services.CustomerNoteService.Commands;

public struct CreateCustomerNoteCommand : IRequest<CustomerNote>
{
    public Ulid ProductId { get; set; }
    public string Description { get; set; }
    public Ulid HashTagIds { get; set; }
    //public File AttachmentFile { get; set; }
    public Ulid CustomerId { get; set; }
}