namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct CustomerNoteByIdHandler : IRequestHandler<CustomerNoteByIdQuery, Result<CustomerNoteResponse>>
{
    readonly ICustomerNoteRepository _repository;

    public CustomerNoteByIdHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteResponse>> Handle(CustomerNoteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerNoteByIdAsync(request.CustomerNoteId))
                .Match(result => new Result<CustomerNoteResponse>(result),
                exception => new Result<CustomerNoteResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new Exception(e.Message));
        }
    }
}