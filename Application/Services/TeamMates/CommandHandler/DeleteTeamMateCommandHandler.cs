namespace Application.Services.TeamMates.CommandHandler;

public readonly struct DeleteTeamMateCommandHandler : IRequestHandler<DeleteTeamMateCommand, Result<TeamMateResponse>>
{
    private readonly ITeamMateRepository _repository;
    
    public DeleteTeamMateCommandHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(DeleteTeamMateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.DeleteTeamMateAsync(request);
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