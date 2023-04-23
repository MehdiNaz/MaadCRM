namespace Application.Services.CustomerNoteService.Commands;

public struct UpdateCustomerNoteCommand : IRequest<CustomerNote>
{
    public Ulid Id { get; set; }
    public Ulid ProductId { get; set; }
    public ICollection<Ulid> HashTagIds { get; set; }
    public ICollection<Ulid> CustomerNoteId { get; set; }
    public string Description { get; set; }
    public required string IdUserUpdated { get; set; }
    public required string IdUserAdded { get; set; }
    public Ulid CustomerId { get; set; }
}