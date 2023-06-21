namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct AddCoWorkerGroupCommandHandler : IRequestHandler<AddCoworkerGroupCommand, Result<TeamMateGroupRespnse>>
{
    private readonly ICoWorkerGroupRepository _repository;
    
    public AddCoWorkerGroupCommandHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupRespnse>> Handle(AddCoworkerGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.AddCoworkerGroupAsync(request);
            return result.Match(
                succ => new Result<TeamMateGroupRespnse>(succ),
                exception => new Result<TeamMateGroupRespnse>(exception)
            );
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupRespnse>(e);
        }
    }
}