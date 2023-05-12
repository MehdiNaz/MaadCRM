namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct UpdateCustomerNoteCommandHandler : IRequestHandler<UpdateCustomerNoteCommand, Result<CustomerNoteResponse>>
{
    private readonly ICustomerNoteRepository _repository;

    public UpdateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNoteResponse>> Handle(UpdateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerNoteCommand item = new()
            {
                Id = request.Id,
                Description = request.Description,
                ProductId = request.ProductId,
                HashTagIds = request.HashTagIds,
            };
            return (await _repository.UpdateCustomerNoteAsync(item))
                .Match(result => new Result<CustomerNoteResponse>(result),
                    exception => new Result<CustomerNoteResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNoteResponse>(new Exception(e.Message));
        }
    }
}