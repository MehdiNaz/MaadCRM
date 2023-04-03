﻿namespace Application.Services.ContactEmailAddressService.CommandHandler;

public class DeleteContactEmailAddressCommandHandler : IRequestHandler<DeleteContactEmailAddressCommand, ContactsEmailAddress>
{
    private readonly IContactsEmailAddressRepository _repository;

    public DeleteContactEmailAddressCommandHandler(IContactsEmailAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactsEmailAddress> Handle(DeleteContactEmailAddressCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteContactsEmailAddressAsync(request.CustomersEmailAddressId))!;
}