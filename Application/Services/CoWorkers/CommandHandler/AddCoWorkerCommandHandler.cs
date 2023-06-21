namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct AddCoWorkerCommandHandler : IRequestHandler<AddCoworkerCommand, Result<bool>>
{
    private readonly ICoWorkerRepository _repository;
    
    public AddCoWorkerCommandHandler(ICoWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(AddCoworkerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.AddCoworkerAsync(request);
            return result.Match(
                succ => new Result<bool>(succ),
                exception => new Result<bool>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<bool>(e);
        }
    }
}