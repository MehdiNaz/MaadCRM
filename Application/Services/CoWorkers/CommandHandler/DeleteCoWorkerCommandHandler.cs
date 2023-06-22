namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct DeleteCoWorkerCommandHandler : IRequestHandler<DeleteCoworkerCommand, Result<TeamMateResponse>>
{
    private readonly ICoWorkerRepository _repository;
    
    public DeleteCoWorkerCommandHandler(ICoWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(DeleteCoworkerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.DeleteCoworkerAsync(request);
            return result.Match(
                succ => new Result<TeamMateResponse>(succ),
                exception => new Result<TeamMateResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(e);
        }
    }
}