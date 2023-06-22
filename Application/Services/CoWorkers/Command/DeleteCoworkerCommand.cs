namespace Application.Services.CoWorkers.Command;

public struct DeleteCoworkerCommand : IRequest<Result<TeamMateResponse>>
{
    public string Id { get; set; }
    public string IdUser { get; set; }
}