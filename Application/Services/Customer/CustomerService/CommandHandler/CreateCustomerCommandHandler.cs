namespace Application.Services.Customer.CustomerService.CommandHandler;

public readonly struct CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.CreateCustomerAsync(request)).Match(result =>
            new Result<CustomerResponse>(result), exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}
