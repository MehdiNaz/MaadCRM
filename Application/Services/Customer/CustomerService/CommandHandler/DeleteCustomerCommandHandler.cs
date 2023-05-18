namespace Application.Services.Customer.CustomerService.CommandHandler;

public readonly struct DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, string>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await _repository.DeleteCustomerAsync(request.CustomerId);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}