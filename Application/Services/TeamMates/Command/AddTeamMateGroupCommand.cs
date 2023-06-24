namespace Application.Services.TeamMates.Command;

public struct AddTeamMateGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public string? IdUser { get; set; }
    public required string Title { get; set; }
    public int? DisplayOrder { get; set; }
    public StatusType? Status { get; set; }
}