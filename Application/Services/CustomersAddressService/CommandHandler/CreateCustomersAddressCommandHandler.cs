namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct CreateCustomersAddressCommandHandler : IRequestHandler<CreateCustomersAddressCommand, CustomerAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public CreateCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerAddress> Handle(CreateCustomersAddressCommand request, CancellationToken cancellationToken)
    {
        CreateCustomersAddressCommand item = new()
        {
            Address = request.Address,
            CodePost = request.CodePost,
            PhoneNo = request.PhoneNo,
            Description = request.Description,
            CustomerId = request.CustomerId,
            IdUser = request.IdUser
        };
        return await _repository.CreateAddressAsync(item);
    }
}
