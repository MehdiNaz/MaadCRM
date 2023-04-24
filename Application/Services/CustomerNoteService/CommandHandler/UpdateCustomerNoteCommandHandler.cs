namespace Application.Services.CustomerNoteService.CommandHandler;

public readonly struct UpdateCustomerNoteCommandHandler : IRequestHandler<UpdateCustomerNoteCommand, Result<CustomerNote>>
{
    private readonly ICustomerNoteRepository _repository;

    public UpdateCustomerNoteCommandHandler(ICustomerNoteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerNote>> Handle(UpdateCustomerNoteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerNoteCommand item = new()
            {
                Id = request.Id,
                Description = request.Description,
                ProductId = request.ProductId,
                HashTagIds = request.HashTagIds,
                IdUser = request.IdUser
            };
            return (await _repository.UpdateCustomerNoteAsync(item)).Match(result => new Result<CustomerNote>(result), exception => new Result<CustomerNote>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerNote>(new Exception(e.Message));
        }
    }
}