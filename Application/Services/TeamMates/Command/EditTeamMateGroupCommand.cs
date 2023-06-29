namespace Application.Services.TeamMates.Command;

public struct EditTeamMateGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public required Ulid Id { get; set; }
    public string? IdUser { get; set; }
    public required string Title { get; set; }
    public int? DisplayOrder { get; set; }
    public StatusType? Status { get; set; }
}