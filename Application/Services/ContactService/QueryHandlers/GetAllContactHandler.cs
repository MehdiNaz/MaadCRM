namespace Application.Services.ContactService.QueryHandlers;

public class GetAllContactHandler : IRequestHandler<GetAllContactQuery, ICollection<Contact?>>
{
    private readonly IContactRepository _repository;

    public GetAllContactHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Contact?>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllContactAsync();
}