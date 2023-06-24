namespace Application.Services.TeamMates.Command;

public struct DeleteTeamMateCommand : IRequest<Result<TeamMateResponse>>
{
    public string Id { get; set; }
    public string IdUser { get; set; }
}