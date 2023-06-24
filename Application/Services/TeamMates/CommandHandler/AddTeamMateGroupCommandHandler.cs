namespace Application.Services.TeamMates.CommandHandler;

public readonly struct AddTeamMateGroupCommandHandler : IRequestHandler<AddTeamMateGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ITeamMateGroupRepository _repository;
    
    public AddTeamMateGroupCommandHandler(ITeamMateGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(AddTeamMateGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.AddTeamMateGroupAsync(request);
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