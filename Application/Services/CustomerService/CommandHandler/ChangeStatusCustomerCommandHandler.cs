namespace Application.Services.CustomerService.CommandHandler;

public readonly struct ChangeStatusCustomerCommandHandler : IRequestHandler<ChangeStatusCustomerCommand, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;

    public ChangeStatusCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> Handle(ChangeStatusCustomerCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusCustomerByIdAsync(request.CustomerStatus, request.CustomerId);
}