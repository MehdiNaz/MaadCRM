namespace Application.Services.CustomerNoteService.QueryHandler;

public readonly struct CustomerNoteByIdHandler : IRequestHandler<CustomerNoteByIdQuery, CustomerNote>
{
    readonly ICustomerNoteRepository _repository;

    public CustomerNoteByIdHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(CustomerNoteByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCustomerNoteByIdAsync(request.CustomerNoteId))!;
}