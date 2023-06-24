namespace Application.Services.TeamMates.CommandHandler;

public readonly struct AddTeamMateCommandHandler : IRequestHandler<AddTeamMateCommand, Result<bool>>
{
    private readonly ITeamMateRepository _repository;
    
    public AddTeamMateCommandHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(AddTeamMateCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.AddTeamMateAsync(request);
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