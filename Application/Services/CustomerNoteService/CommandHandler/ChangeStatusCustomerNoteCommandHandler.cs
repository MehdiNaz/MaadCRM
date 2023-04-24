namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct ChangeStatusCustomerNoteCommandHandler : IRequestHandler<ChangeStatusCustomerNoteCommand, Result<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public ChangeStatusCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNote>> Handle(ChangeStatusCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerNoteByIdAsync(request)).Match(result => new Result<CustomerNote>(result), exception => new Result<CustomerNote>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new Exception(e.Message));
        }
    }
}