namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct CreateCustomersAddressCommandHandler : IRequestHandler<CreateCustomersAddressCommand, CustomersAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public CreateCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress> Handle(CreateCustomersAddressCommand request, CancellationToken cancellationToken)
    {
        CustomersAddress item = new()
        {
            Address = request.Address,
            CodePost = request.CodePost,
            PhoneNo = request.PhoneNo,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.CreateAddressAsync(item);
        return item;
    }
}
