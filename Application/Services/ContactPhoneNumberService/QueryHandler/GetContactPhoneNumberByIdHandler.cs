namespace Application.Services.ContactPhoneNumberService.QueryHandler;

public class GetContactPhoneNumberByIdHandler : IRequestHandler<GetContactPhoneNumberByIdQuery, ContactPhoneNumber?>
{
    private readonly IContactPhoneNumberRepository _repository;

    public GetContactPhoneNumberByIdHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContactPhoneNumber?> Handle(GetContactPhoneNumberByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetContactPhoneNumberByIdAsync(request.ContactPhoneNumberId);
}