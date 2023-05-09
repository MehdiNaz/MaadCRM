namespace Application.Services.CustomerNoteService.Commands;

public struct ChangeStatusCustomerNoteCommand : IRequest<Result<CustomerNote>>
{
    public Ulid CustomerNoteId { get; set; }
    public StatusType CustomerNoteStatusType { get; set; }
}