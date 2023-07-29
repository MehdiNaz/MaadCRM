namespace Application.Services.TeamMates.Command;

public struct ChangePermissionCommand : IRequest<Result<TeamMateResponse>>
{
    public string Id { get; set; }
    public string IdUser { get; set; }
    public UserPermissionType Permission { get; set; }
}