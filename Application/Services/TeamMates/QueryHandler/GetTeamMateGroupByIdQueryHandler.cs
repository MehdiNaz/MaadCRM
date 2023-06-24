using Application.Services.TeamMates.Query;

namespace Application.Services.TeamMates.QueryHandler;

public readonly struct GetTeamMateGroupByIdQueryHandler : IRequestHandler<GetTeamMateGroupByIdQuery, Result<TeamMateGroupResponse>>
{
    private readonly ITeamMateGroupRepository _repository;

    public GetTeamMateGroupByIdQueryHandler(ITeamMateGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(GetTeamMateGroupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetTeamMateGroupById(request)).Match(result => new Result<TeamMateGroupResponse>(result), exception => new Result<TeamMateGroupResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(new Exception(e.Message));
        }
    }
}