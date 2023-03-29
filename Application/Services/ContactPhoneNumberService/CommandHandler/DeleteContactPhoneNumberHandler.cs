namespace Application.Services.ContactPhoneNumberService.CommandHandler;

public class DeleteContactPhoneNumberHandler : IRequestHandler<DeleteContactPhoneNumberCommand, ContactPhoneNumber>
{
    private readonly IContactPhoneNumberRepository _repository;

    public DeleteContactPhoneNumberHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber> Handle(DeleteContactPhoneNumberCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteContactPhoneNumberAsync(request.ContactPhoneNumberId))!;
}