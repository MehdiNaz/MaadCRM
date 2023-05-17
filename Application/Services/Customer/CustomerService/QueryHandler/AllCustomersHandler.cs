using Application.Services.Customer.CustomerService.Query;

namespace Application.Services.Customer.CustomerService.QueryHandler;

public readonly struct AllCustomersHandler : IRequestHandler<AllCustomersQuery, Result<ICollection<CustomerResponse>>>
{
    private readonly ICustomerRepository _repository;

    public AllCustomersHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerResponse>>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomersAsync(request.UserId)).Match(result => new Result<ICollection<CustomerResponse>>(result), exception => new Result<ICollection<CustomerResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerResponse>>(new Exception(e.Message));
        }
    }
}