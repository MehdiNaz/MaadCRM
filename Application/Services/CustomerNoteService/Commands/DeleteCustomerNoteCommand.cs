namespace Application.Services.CustomerNoteService.Commands;

public struct DeleteCustomerNoteCommand : IRequest<Result<CustomerNoteResponse>>
{
    public Ulid Id { get; set; }
    public string UserId { get; set; }
}