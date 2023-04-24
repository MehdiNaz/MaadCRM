namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct CustomerNoteByIdHandler : IRequestHandler<CustomerNoteByIdQuery, Result<CustomerNote>>
{
    readonly ICustomerNoteRepository _repository;

    public CustomerNoteByIdHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNote>> Handle(CustomerNoteByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerNoteByIdAsync(request.CustomerNoteId)).Match(result => new Result<CustomerNote>(result), exception => new Result<CustomerNote>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new Exception(e.Message));
        }
    }
}