namespace Application.Services.CustomerNoteService.Queries;

public struct CustomerNoteByIdQuery : IRequest<Result<CustomerNote>>
{
    public Ulid CustomerNoteId { get; set; }
}