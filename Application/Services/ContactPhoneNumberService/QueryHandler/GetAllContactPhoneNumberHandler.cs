namespace Application.Services.ContactPhoneNumberService.QueryHandler;

public class GetAllContactPhoneNumberHandler : IRequestHandler<GetAllContactPhoneNumberQuery, ICollection<ContactPhoneNumber>>
{
    private readonly IContactPhoneNumberRepository _repository;

    public GetAllContactPhoneNumberHandler(IContactPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ContactPhoneNumber>> Handle(GetAllContactPhoneNumberQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllContactPhoneNumberAsync())!;
}