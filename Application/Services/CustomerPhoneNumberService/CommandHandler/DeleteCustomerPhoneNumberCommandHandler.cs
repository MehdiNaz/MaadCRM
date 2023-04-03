namespace Application.Services.CustomerPhoneNumberService.CommandHandler;

public class DeleteCustomerPhoneNumberCommandHandler : IRequestHandler<DeleteCustomerPhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public DeleteCustomerPhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(DeleteCustomerPhoneNumberCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePhoneNumberAsync(request.PhoneNumberId))!;
}