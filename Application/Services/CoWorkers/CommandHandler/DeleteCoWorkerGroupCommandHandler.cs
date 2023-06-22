namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct DeleteCoWorkerGroupCommandHandler : IRequestHandler<DeleteCoworkerGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ICoWorkerGroupRepository _repository;
    
    public DeleteCoWorkerGroupCommandHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(DeleteCoworkerGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.DeleteCoworkerGroupAsync(request);
            return result.Match(
                succ => new Result<TeamMateGroupResponse>(succ),
                exception => new Result<TeamMateGroupResponse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(e);
        }
    }
}