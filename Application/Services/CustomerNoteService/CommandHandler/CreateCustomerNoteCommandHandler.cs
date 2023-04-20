using Domain.Models.Customers.Notes;

namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct CreateCustomerNoteCommandHandler : IRequestHandler<CreateCustomerNoteCommand, CustomerNote>
{
    private readonly ICustomerNoteRepository _repository;

    public CreateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(CreateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerNoteCommand item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId,
            ProductId = request.ProductId,
            HashTagIds = request.HashTagIds,
            CustomerNoteId=request.CustomerNoteId
        };
        return await _repository.CreateCustomerNoteAsync(item);
    }
}