namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct AllCustomerNoteHandler : IRequestHandler<AllCustomerNotesQuery, Result<ICollection<CustomerNoteHashTableResponse>>>
{
    private readonly ICustomerNoteRepository _repository;

    public AllCustomerNoteHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerNoteHashTableResponse>>> Handle(AllCustomerNotesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerNotesAsync(request.CustomerId))
                .Match(result => new Result<ICollection<CustomerNoteHashTableResponse>>(result),
                exception => new Result<ICollection<CustomerNoteHashTableResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteHashTableResponse>>(new Exception(e.Message));
        }
    }
}