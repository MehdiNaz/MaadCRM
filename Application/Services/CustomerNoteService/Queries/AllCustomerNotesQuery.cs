namespace Application.Services.CustomerNoteService.Queries;

public struct AllCustomerNotesQuery : IRequest<ICollection<CustomerNote>>
{
    public Ulid CustomerId { get; set; }
}