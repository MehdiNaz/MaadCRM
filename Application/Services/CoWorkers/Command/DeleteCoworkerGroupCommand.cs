namespace Application.Services.CoWorkers.Command;

public struct DeleteCoworkerGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public string? Id { get; set; }
    public string? IdUser { get; set; }
}