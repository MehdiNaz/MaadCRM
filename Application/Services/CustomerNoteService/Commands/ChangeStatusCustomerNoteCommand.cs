namespace Application.Services.CustomerNoteService.Commands;

public struct ChangeStatusCustomerNoteCommand : IRequest<Result<CustomerNote>>
{
    public Ulid CustomerNoteId { get; set; }
    public Status CustomerNoteStatus { get; set; }
}