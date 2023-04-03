namespace Application.Services.CustomerNoteService.Commands;

public struct CreateCustomerNoteCommand : IRequest<CustomerNote>
{
    public string Description { get; set; }
    public Ulid CustomerId { get; set; }
}