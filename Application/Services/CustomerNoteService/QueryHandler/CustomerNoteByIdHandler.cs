namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct CustomerNoteByIdHandler : IRequestHandler<CustomerNoteByIdQuery, Result<CustomerNoteHashTableResponse>>
{
    readonly ICustomerNoteRepository _repository;

    public CustomerNoteByIdHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteHashTableResponse>> Handle(CustomerNoteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerNoteByIdAsync(request.CustomerNoteId))
                .Match(result => new Result<CustomerNoteHashTableResponse>(result),
                exception => new Result<CustomerNoteHashTableResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteHashTableResponse>(new Exception(e.Message));
        }
    }
}