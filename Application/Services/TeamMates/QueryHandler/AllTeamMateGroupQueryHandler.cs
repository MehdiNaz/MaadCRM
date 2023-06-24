using Application.Services.TeamMates.Query;

namespace Application.Services.TeamMates.QueryHandler;

public readonly struct AllTeamMateGroupQueryHandler : IRequestHandler<AllUserGroupsQuery, Result<ICollection<TeamMateGroupResponse>>>
{
    private readonly ITeamMateGroupRepository _repository;

    public AllTeamMateGroupQueryHandler(ITeamMateGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<TeamMateGroupResponse>>> Handle(AllUserGroupsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.AllTeamMateGroupsAsync(request)).Match(result => new Result<ICollection<TeamMateGroupResponse>>(result), exception => new Result<ICollection<TeamMateGroupResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateGroupResponse>>(new Exception(e.Message));
        }
    }
}