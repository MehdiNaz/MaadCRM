namespace Application.Services.CustomerNoteService.Commands;

public struct UpdateCustomerNoteCommand : IRequest<CustomerNote>
{
    public Ulid CustomerNoteId { get; set; }
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
}