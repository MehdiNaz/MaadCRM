namespace Application.Services.PhoneNumberService.QueryHandlers;

public class GetPhoneNumberByIdHandler : IRequestHandler<GetPhoneNumberById, PhoneNumber?>
{
    private readonly IPhoneNumberRepository _repository;

    public GetPhoneNumberByIdHandler(IPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneNumber?> Handle(GetPhoneNumberById request, CancellationToken cancellationToken)
        => await _repository.GetPhoneNumberByIdAsync(request.PhoneNumberId);
}