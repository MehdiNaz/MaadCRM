namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct AddCoWorkerGroupCommandHandler : IRequestHandler<AddCoworkerGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ICoWorkerGroupRepository _repository;
    
    public AddCoWorkerGroupCommandHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(AddCoworkerGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.AddCoworkerGroupAsync(request);
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