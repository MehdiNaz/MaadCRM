namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct ChangeStatusCustomerNoteCommandHandler : IRequestHandler<ChangeStatusCustomerNoteCommand, Result<CustomerNoteResponse>>
{
    private readonly ICustomerNoteRepository _repository;

    public ChangeStatusCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteResponse>> Handle(ChangeStatusCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerNoteByIdAsync(request))
                .Match(result => new Result<CustomerNoteResponse>(result),
                    exception => new Result<CustomerNoteResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new Exception(e.Message));
        }
    }
}