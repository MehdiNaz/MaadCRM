namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct AllCustomerNoteHandler : IRequestHandler<AllCustomerNotesQuery, Result<ICollection<CustomerNote>>>
{
    private readonly ICustomerNoteRepository _repository;

    public AllCustomerNoteHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerNote>>> Handle(AllCustomerNotesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerNotesAsync(request.CustomerId)).Match(result => new Result<ICollection<CustomerNote>>(result), exception => new Result<ICollection<CustomerNote>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerNote>>(new Exception(e.Message));
        }
    }
}