namespace Application.Services.CustomerNoteService.Queries;

public struct CustomerNoteByIdQuery : IRequest<CustomerNote>
{
    public Ulid CustomerNoteId { get; set; }
}