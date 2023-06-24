namespace Application.Services.TeamMates.CommandHandler;

public readonly struct DeleteCoWorkerGroupCommandHandler : IRequestHandler<DeleteTeamMateGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ITeamMateGroupRepository _repository;
    
    public DeleteCoWorkerGroupCommandHandler(ITeamMateGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(DeleteTeamMateGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.DeleteTeamMateGroupAsync(request);
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