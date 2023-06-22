namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct EditCoWorkerCommandHandler : IRequestHandler<EditCoworkerCommand, Result<TeamMateResponse>>
{
    private readonly ICoWorkerRepository _repository;
    
    public EditCoWorkerCommandHandler(ICoWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(EditCoworkerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.EditCoworkerAsync(request);
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