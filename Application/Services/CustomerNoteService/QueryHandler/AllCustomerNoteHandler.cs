namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct AllCustomerNoteHandler : IRequestHandler<AllCustomerNotesQuery, ICollection<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public AllCustomerNoteHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerNote>> Handle(AllCustomerNotesQuery request, CancellationToken cancellationToken)
        => (await _repository.GetAllCustomerNotesAsync())!;
}