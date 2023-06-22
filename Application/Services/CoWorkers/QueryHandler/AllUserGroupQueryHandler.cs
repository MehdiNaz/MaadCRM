namespace Application.Services.CoWorkers.QueryHandler;

public readonly struct AllUserGroupQueryHandler : IRequestHandler<AllUserGroupsQuery, Result<ICollection<TeamMateGroupResponse>>>
{
    private readonly ICoWorkerGroupRepository _repository;

    public AllUserGroupQueryHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<TeamMateGroupResponse>>> Handle(AllUserGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.AllCoworkerGroupAsync(request)).Match(result => new Result<ICollection<TeamMateGroupResponse>>(result), exception => new Result<ICollection<TeamMateGroupResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateGroupResponse>>(new Exception(e.Message));
        }
    }
}