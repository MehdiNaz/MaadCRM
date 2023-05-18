namespace Application.Services.Customer.CustomerService.CommandHandler;

public readonly struct ChangeStateCustomerCommandHandler : IRequestHandler<ChangeStateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public ChangeStateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(ChangeStateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStateCustomerByIdAsync(request))
                .Match(result => new Result<CustomerResponse>(result),
                exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}
