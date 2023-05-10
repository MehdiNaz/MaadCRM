namespace Application.Services.CustomerNoteService.Commands;

public struct ChangeStatusCustomerNoteCommand : IRequest<Result<CustomerNoteResponse>>
{
    public Ulid CustomerNoteId { get; set; }
    public StatusType CustomerNoteStatusType { get; set; }
}