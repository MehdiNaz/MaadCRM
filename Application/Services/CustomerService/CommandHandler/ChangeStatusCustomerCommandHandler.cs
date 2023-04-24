namespace Application.Services.CustomerService.CommandHandler;

public readonly struct ChangeStatusCustomerCommandHandler : IRequestHandler<ChangeStatusCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public ChangeStatusCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(ChangeStatusCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerByIdAsync(request)).Match(result => new Result<CustomerResponse>(result), exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}