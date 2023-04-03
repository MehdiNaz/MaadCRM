namespace Application.Services.CustomersAddressService.CommandHandler;

public class UpdateCustomersAddressCommandHandler : IRequestHandler<UpdateCustomersAddressCommand, CustomersAddress>
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
            Address = request.Address,
            CodePost = request.CodePost,
            PhoneNo = request.PhoneNo,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateAddressAsync(item, request.CustomersAddressId);
        return item;
    }
}