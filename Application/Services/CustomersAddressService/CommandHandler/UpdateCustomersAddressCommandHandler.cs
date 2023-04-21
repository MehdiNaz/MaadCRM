namespace Application.Services.CustomersAddressService.CommandHandler;

public readonly struct UpdateCustomersAddressCommandHandler : IRequestHandler<UpdateCustomersAddressCommand, CustomerAddress>
{
    private readonly ICustomersAddressRepository _repository;

    public UpdateCustomersAddressCommandHandler(ICustomersAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerAddress> Handle(UpdateCustomersAddressCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomersAddressCommand item = new()
        {
            Id = request.Id,
            Address = request.Address,
            CodePost = request.CodePost,
            PhoneNo = request.PhoneNo,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        return await _repository.UpdateAddressAsync(item);
    }
}