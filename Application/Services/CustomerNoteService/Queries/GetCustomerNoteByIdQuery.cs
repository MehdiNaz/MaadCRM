namespace Application.Services.CustomerNoteService.Queries;

public struct GetCustomerNoteByIdQuery : IRequest<CustomerNote>
{
    public Ulid CustomerNoteId { get; set; }
}