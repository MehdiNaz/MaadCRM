namespace Application.Services.PhoneNumberService.CommandHandlers;

public class DeletePhoneNumberHandler : IRequestHandler<DeletePhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public DeletePhoneNumberHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePhoneNumberAsync(request.PhoneNumberId))!;
}