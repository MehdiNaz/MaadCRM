namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public readonly struct UpdateContactPhoneNumberCommandHandler : IRequestHandler<UpdateContactPhoneNumberCommand, ContactPhoneNumber>
{
    private readonly IContactPhoneNumberRepository _repository;

    public UpdateContactPhoneNumberCommandHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber> Handle(UpdateContactPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        ContactPhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateContactPhoneNumberAsync(item, request.ContactPhoneNumberId);
        return item;
    }
}