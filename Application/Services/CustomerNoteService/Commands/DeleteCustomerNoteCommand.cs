namespace Application.Services.CustomerNoteService.Commands;

public struct DeleteCustomerNoteCommand : IRequest<CustomerNote>
{
    public Ulid Id { get; set; }
}