namespace Application.Services.CustomerNoteService.Queries;

public struct AllCustomerNotesQuery : IRequest<Result<ICollection<CustomerNote>>>
{
    public Ulid CustomerId { get; set; }
}