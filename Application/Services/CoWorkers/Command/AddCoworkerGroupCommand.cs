namespace Application.Services.CoWorkers.Command;

public struct AddCoworkerGroupCommand : IRequest<Result<TeamMateGroupRespnse>>
{
    public string? IdUser { get; set; }
    public required string Title { get; set; }
    public int? DisplayOrder { get; set; }
    public StatusType? Status { get; set; }
}