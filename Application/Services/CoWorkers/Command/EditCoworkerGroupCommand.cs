namespace Application.Services.CoWorkers.Command;

public struct EditCoworkerGroupCommand : IRequest<Result<TeamMateGroupResponse>>
{
    public string? Id { get; set; }
    public string? IdUser { get; set; }
    public required string Title { get; set; }
    public int? DisplayOrder { get; set; }
    public StatusType? Status { get; set; }
}