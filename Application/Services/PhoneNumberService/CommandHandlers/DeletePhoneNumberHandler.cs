namespace Application.Services.PhoneNumberService.CommandHandlers;

public class DeletePhoneNumberHandler : IRequestHandler<DeletePhoneNumberCommand, PhoneNumber>
{
    private readonly IPhoneNumberRepository _repository;

    public DeletePhoneNumberHandler(IPhoneNumberRepository repository)
    {
        _repository = repository;
    }

    public async Task<PhoneNumber> Handle(DeletePhoneNumberCommand request, CancellationToken cancellationToken)
        => (await _repository.DeletePhoneNumberAsync(request.PhoneNumberId))!;
}