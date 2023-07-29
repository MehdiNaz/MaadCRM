namespace Application.Services.TeamMates.CommandHandler;

public readonly struct ChangePermissionCommandHandler : IRequestHandler<ChangePermissionCommand, Result<TeamMateResponse>>
{
    private readonly ITeamMateRepository _repository;
    
    public ChangePermissionCommandHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(ChangePermissionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.ChangePermissionAsync(request);
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