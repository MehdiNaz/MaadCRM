namespace Application.Services.CustomerNoteService.CommandHandler;

public class CreateCustomerNoteCommandHandler : IRequestHandler<CreateCustomerNoteCommand, CustomerNote>
{
    private readonly ICustomerNoteRepository _repository;

    public CreateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(CreateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        CustomerNote item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.CreateCustomerNoteAsync(item);
        return item;
    }
}