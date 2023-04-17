namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct CreateCustomerNoteCommandHandler : IRequestHandler<CreateCustomerNoteCommand, CustomerNoteResponse?>
{
    private readonly ICustomerNoteRepository _repository;

    public CreateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNoteResponse?> Handle(CreateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerNoteCommand item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId,
            ProductId = request.ProductId
        };
        var result = await _repository.CreateCustomerNoteAsync(item);
        return result.Select(x => new CustomerNoteResponse()
        {
            CustomerId = item.CustomerId,
            ProductId = item.ProductId,
            CustomerNoteStatus = item.CustomerNoteStatus,
            Description = item.Description
        });
    }
}