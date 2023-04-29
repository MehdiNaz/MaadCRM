namespace Application.Services.CustomerNoteService.Queries;

public struct CustomerNoteByIdQuery : IRequest<Result<CustomerNoteHashTableResponse>>
{
    public Ulid CustomerNoteId { get; set; }
}