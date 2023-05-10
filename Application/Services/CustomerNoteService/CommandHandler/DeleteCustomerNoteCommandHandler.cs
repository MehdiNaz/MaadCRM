namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct DeleteCustomerNoteCommandHandler : IRequestHandler<DeleteCustomerNoteCommand, Result<CustomerNoteResponse>>
{
    private readonly ICustomerNoteRepository _repository;

    public DeleteCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteResponse>> Handle(DeleteCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerNoteAsync(request.Id))
                .Match(result => new Result<CustomerNoteResponse>(result),
                    exception => new Result<CustomerNoteResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new Exception(e.Message));
        }
    }
}