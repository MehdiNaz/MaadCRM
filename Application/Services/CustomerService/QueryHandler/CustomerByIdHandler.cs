namespace Application.Services.CustomerService.QueryHandler;

public readonly struct CustomerByIdHandler : IRequestHandler<CustomerByIdQuery, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public CustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerByIdAsync(request.CustomerId))
                .Match(result => new Result<CustomerResponse>(result),
                    exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}