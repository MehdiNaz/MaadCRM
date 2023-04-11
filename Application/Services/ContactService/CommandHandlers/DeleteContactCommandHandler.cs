namespace Application.Services.ContactService.CommandHandlers;

public readonly struct DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public DeleteContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteContactAsync(request.ContactId))!;
}