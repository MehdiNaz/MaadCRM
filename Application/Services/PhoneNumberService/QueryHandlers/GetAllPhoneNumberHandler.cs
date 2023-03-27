namespace Application.Services.PhoneNumberService.QueryHandlers;

public class GetAllPhoneNumberHandler : IRequestHandler<GetAllPhoneNumberQuery, ICollection<PhoneNumber?>>
{
    private readonly IPhoneNumberRepository _repository;

    public GetAllPhoneNumberHandler(IPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<PhoneNumber?>> Handle(GetAllPhoneNumberQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllPhoneNumbersAsync();
}