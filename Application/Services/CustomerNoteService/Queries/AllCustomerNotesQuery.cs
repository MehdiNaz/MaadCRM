namespace Application.Services.CustomerNoteService.Queries;

public struct AllCustomerNotesQuery : IRequest<Result<ICollection<CustomerNoteResponse>>>
{
    public Ulid CustomerId { get; set; }
}