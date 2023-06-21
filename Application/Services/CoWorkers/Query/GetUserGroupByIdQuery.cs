namespace Application.Services.CoWorkers.Query;

public struct GetUserGroupByIdQuery : IRequest<Result<TeamMateGroupRespnse>>
{
    public Ulid Id { get; set; }
    public string IdUser { get; set; }
}