namespace Application.Services.CustomerNoteService.QueryHandler;

public class GetAllCustomerNoteHandler : IRequestHandler<GetAllCustomerNoteQuery, ICollection<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public GetAllCustomerNoteHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerNote>> Handle(GetAllCustomerNoteQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCustomerNotesAsync())!;
}