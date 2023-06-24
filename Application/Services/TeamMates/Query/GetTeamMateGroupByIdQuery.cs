namespace Application.Services.TeamMates.Query;

public struct GetTeamMateGroupByIdQuery : IRequest<Result<TeamMateGroupResponse>>
{
    public Ulid Id { get; set; }
    public string IdUser { get; set; }
}