namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct AllCustomerNoteHandler : IRequestHandler<AllCustomerNotesQuery, Result<ICollection<CustomerNoteResponse>>>
{
    private readonly ICustomerNoteRepository _repository;

    public AllCustomerNoteHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerNoteResponse>>> Handle(AllCustomerNotesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerNotesAsync(request.CustomerId))
                .Match(result => new Result<ICollection<CustomerNoteResponse>>(result),
                exception => new Result<ICollection<CustomerNoteResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNoteResponse>>(new Exception(e.Message));
        }
    }
}