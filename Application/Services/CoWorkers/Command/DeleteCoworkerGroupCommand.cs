namespace Application.Services.CoWorkers.Command;

public struct DeleteCoworkerGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public required Ulid Id { get; set; }
    public string? IdUser { get; set; }
}