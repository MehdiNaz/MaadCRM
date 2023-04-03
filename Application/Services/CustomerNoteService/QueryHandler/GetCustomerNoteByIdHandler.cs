namespace Application.Services.CustomerNoteService.QueryHandler;

public class GetCustomerNoteByIdHandler : IRequestHandler<GetCustomerNoteByIdQuery, CustomerNote>
{
    readonly ICustomerNoteRepository _repository;

    public GetCustomerNoteByIdHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(GetCustomerNoteByIdQuery request, CancellationToken cancellationToken)
        => (await _repository.GetCustomerNoteByIdAsync(request.CustomerNoteId))!;
}