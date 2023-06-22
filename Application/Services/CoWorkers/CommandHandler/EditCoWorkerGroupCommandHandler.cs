namespace Application.Services.CoWorkers.CommandHandler;

public readonly struct EditCoWorkerGroupCommandHandler : IRequestHandler<EditCoworkerGroupCommand, Result<TeamMateGroupResponse>>
{
    private readonly ICoWorkerGroupRepository _repository;
    
    public EditCoWorkerGroupCommandHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(EditCoworkerGroupCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.EditCoworkerGroupAsync(request);
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