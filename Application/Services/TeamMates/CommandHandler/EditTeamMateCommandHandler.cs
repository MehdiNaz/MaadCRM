namespace Application.Services.TeamMates.CommandHandler;

public readonly struct EditTeamMateCommandHandler : IRequestHandler<EditTeamMateCommand, Result<TeamMateResponse>>
{
    private readonly ITeamMateRepository _repository;
    
    public EditTeamMateCommandHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(EditTeamMateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.EditTeamMateAsync(request);
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