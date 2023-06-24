namespace Application.Services.TeamMates.CommandHandler;

public readonly struct EditTeamMateGroupCommandHandler : IRequestHandler<EditTeamMateGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ITeamMateGroupRepository _repository;
    
    public EditTeamMateGroupCommandHandler(ITeamMateGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(EditTeamMateGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.EditTeamMateGroupAsync(request);
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