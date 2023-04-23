namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct UpdateCustomerNoteCommandHandler : IRequestHandler<UpdateCustomerNoteCommand, CustomerNote>
{
    private readonly ICustomerNoteRepository _repository;

    public UpdateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(UpdateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerNoteCommand item = new()
        {
            Id = request.Id,
            Description = request.Description,
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
            HashTagIds = request.HashTagIds,
            CustomerNoteId = request.CustomerNoteId,
            IdUserAdded = request.IdUserAdded,
            IdUserUpdated = request.IdUserUpdated
        };
        return await _repository.UpdateCustomerNoteAsync(item);
    }
}