namespace Application.Services.CoWorkers.QueryHandler;

public readonly struct AllUserGroupQueryHandler : IRequestHandler<AllUserGroupsQuery, Result<ICollection<TeamMateGroupRespnse>>>
{
    private readonly ICoWorkerGroupRepository _repository;

    public AllUserGroupQueryHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<TeamMateGroupRespnse>>> Handle(AllUserGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.AllCoworkerGroupAsync(request)).Match(result => new Result<ICollection<TeamMateGroupRespnse>>(result), exception => new Result<ICollection<TeamMateGroupRespnse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateGroupRespnse>>(new Exception(e.Message));
        }
    }
}