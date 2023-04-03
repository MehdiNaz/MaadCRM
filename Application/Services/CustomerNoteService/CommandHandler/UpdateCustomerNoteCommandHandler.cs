namespace Application.Services.CustomerNoteService.CommandHandler;

public class UpdateCustomerNoteCommandHandler : IRequestHandler<UpdateCustomerNoteCommand, CustomerNote>
{
    private readonly ICustomerNoteRepository _repository;

    public UpdateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(UpdateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        CustomerNote item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateCustomerNoteAsync(item, request.CustomerNoteId);
        return item;
    }
}