namespace Application.Services.TeamMates.Command;

public struct DeleteTeamMateGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public required Ulid Id { get; set; }
    public string? IdUser { get; set; }
}