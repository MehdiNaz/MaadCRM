namespace Application.Services.Customer.CustomerService.QueryHandler;

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
            return await _repository.GetCustomerByIdAsync(request.CustomerId, request.UserId);
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}