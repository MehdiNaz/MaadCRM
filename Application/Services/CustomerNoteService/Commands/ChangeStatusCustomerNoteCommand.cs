namespace Application.Services.CustomerNoteService.Commands;

public struct ChangeStatusCustomerNoteCommand : IRequest<CustomerNote?>
{
    public Ulid CustomerNoteId { get; set; }
    public Status CustomerNoteStatus { get; set; }
}