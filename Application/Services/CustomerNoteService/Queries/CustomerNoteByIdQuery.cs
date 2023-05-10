namespace Application.Services.CustomerNoteService.Queries;

public struct CustomerNoteByIdQuery : IRequest<Result<CustomerNoteResponse>>
{
    public Ulid CustomerNoteId { get; set; }
}