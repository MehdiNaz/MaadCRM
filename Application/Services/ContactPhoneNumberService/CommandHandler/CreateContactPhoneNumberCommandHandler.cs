namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public readonly struct CreateContactPhoneNumberCommandHandler : IRequestHandler<CreateContactPhoneNumberCommand, ContactPhoneNumber>
{
    private readonly IContactPhoneNumberRepository _repository;

    public CreateContactPhoneNumberCommandHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber> Handle(CreateContactPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        CreateContactPhoneNumberCommand item = new()
        {
            PhoneNo = request.PhoneNo,
            CustomerId = request.CustomerId
        };
        return await _repository.CreateContactPhoneNumberAsync(item);
    }
}
