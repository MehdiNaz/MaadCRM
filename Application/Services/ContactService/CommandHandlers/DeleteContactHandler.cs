namespace Application.Services.ContactService.CommandHandlers;

public class DeleteContactHandler : IRequestHandler<DeleteContactCommand, Contact>
{
    private readonly IContactRepository _repository;

    public DeleteContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<Contact> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteContactAsync(request.ContactId))!;
}