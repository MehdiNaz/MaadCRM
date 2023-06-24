namespace Application.Services.TeamMates.Query;

public struct GetTeamMateByIdQuery : IRequest<Result<TeamMateResponse>>
{
    public string Id { get; set; }
    public string IdUser { get; set; }
}