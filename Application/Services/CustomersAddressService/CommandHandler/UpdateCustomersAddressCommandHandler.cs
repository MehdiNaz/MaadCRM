namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct UpdateCustomersAddressCommandHandler : IRequestHandler<UpdateCustomersAddressCommand, CustomersAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public UpdateCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersAddress> Handle(UpdateCustomersAddressCommand request, CancellationToken cancellationToken)
    {
        CustomersAddress item = new()
        {
            CustomersAddressId= request.CustomersAddressId,
            Address = request.Address,
            CodePost = request.CodePost,
            PhoneNo = request.PhoneNo,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateAddressAsync(item);
        return item;
    }
}