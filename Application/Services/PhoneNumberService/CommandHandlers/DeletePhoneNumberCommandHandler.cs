namespace Application.Services.PhoneNumberService.CommandHandlers;

public readonly struct DeletePhoneNumberCommandHandler : IRequestHandler<DeletePhoneNumberCommand, CustomersPhoneNumber>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public DeletePhoneNumberCommandHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePhoneNumberAsync(request.PhoneNumberId))!;
}