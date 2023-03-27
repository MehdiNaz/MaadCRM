namespace Application.Services.PhoneNumberService.CommandHandlers;

public class UpdatePhoneNumberHandler : IRequestHandler<UpdatePhoneNumberCommand, PhoneNumber>
{
    private readonly IPhoneNumberRepository _repository;

    public UpdatePhoneNumberHandler(IPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneNumber> Handle(UpdatePhoneNumberCommand request, CancellationToken cancellationToken)
    {
        PhoneNumber item = new()
        {
            PhoneNo = request.PhoneNo,
            PhoneType = request.PhoneType,
            CustomerId = request.CustomerId,
            IsDeleted = request.IsDeleted
        };
        await _repository.UpdatePhoneNumberAsync(item, request.PhoneNumberId);
        return item;
    }
}
