namespace Application.Services.CustomerService.CommandHandler;

public readonly struct DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerAsync(request.CustomerId)).Match(result => new Result<CustomerResponse>(result), exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}