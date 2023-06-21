namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct EditCoWorkerGroupCommandHandler : IRequestHandler<EditCoworkerGroupCommand, Result<TeamMateGroupRespnse>>
{
    private readonly ICoWorkerGroupRepository _repository;
    
    public EditCoWorkerGroupCommandHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupRespnse>> Handle(EditCoworkerGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.EditCoworkerGroupAsync(request);
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