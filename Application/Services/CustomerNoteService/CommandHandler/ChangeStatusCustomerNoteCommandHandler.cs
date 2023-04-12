namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct ChangeStatusCustomerNoteCommandHandler : IRequestHandler<ChangeStatusCustomerNoteCommand, CustomerNote?>
{
    private readonly ICustomerNoteRepository _repository;

    public ChangeStatusCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerNote?> Handle(ChangeStatusCustomerNoteCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusCustomerNoteByIdAsync(request.CustomerNoteStatus, request.CustomerNoteId);
}