﻿namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public class CreateContactPhoneNumberHandler : IRequestHandler<CreateContactPhoneNumberCommand, ContactPhoneNumber>
{
    private readonly IContactPhoneNumberRepository _repository;

    public CreateContactPhoneNumberHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber> Handle(CreateContactPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        ContactPhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            ContactPhoneNumberId = request.CustomerId
        };
        await _repository.CreateContactPhoneNumberAsync(item);
        return item;
    }
}
