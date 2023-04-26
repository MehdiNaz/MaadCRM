namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct DeleteCustomerNoteCommandHandler : IRequestHandler<DeleteCustomerNoteCommand, Result<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public DeleteCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNote>> Handle(DeleteCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerNoteAsync(request.Id)).Match(result => new Result<CustomerNote>(result), exception => new Result<CustomerNote>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new Exception(e.Message));
        }
    }
}