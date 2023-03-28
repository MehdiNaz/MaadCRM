namespace Application.Services.PhoneNumberService.QueryHandlers;

public class GetPhoneNumberByIdHandler : IRequestHandler<GetPhoneNumberById, CustomersPhoneNumber?>
{
    private readonly ICustomersPhoneNumberRepository _repository;

    public GetPhoneNumberByIdHandler(ICustomersPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomersPhoneNumber?> Handle(GetPhoneNumberById request, CancellationToken cancellationToken)
        => await _repository.GetPhoneNumberByIdAsync(request.PhoneNumberId);
}