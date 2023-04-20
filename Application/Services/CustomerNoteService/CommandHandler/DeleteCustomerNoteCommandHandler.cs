namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct DeleteCustomerNoteCommandHandler : IRequestHandler<DeleteCustomerNoteCommand, CustomerNote>
{
    private readonly ICustomerNoteRepository _repository;

    public DeleteCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote> Handle(DeleteCustomerNoteCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCustomerNoteAsync(request))!;
}