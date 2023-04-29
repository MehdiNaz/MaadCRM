namespace Application.Services.CustomerNoteService.Queries;

public struct AllCustomerNotesQuery : IRequest<Result<ICollection<CustomerNoteHashTableResponse>>>
{
    public Ulid CustomerId { get; set; }
}