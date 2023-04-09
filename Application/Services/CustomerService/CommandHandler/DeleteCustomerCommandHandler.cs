namespace Application.Services.CustomerService.CommandHandler;

public readonly struct DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCustomerAsync(request.CustomerId))!;
}