namespace Application.Services.CustomerService.CommandHandler;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCustomerAsync(request.CustomerId))!;
}