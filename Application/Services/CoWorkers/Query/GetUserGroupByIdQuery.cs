namespace Application.Services.CoWorkers.Query;

public struct GetUserGroupByIdQuery : IRequest<Result<TeamMateGroupResponse>>
{
    public Ulid Id { get; set; }
    public string IdUser { get; set; }
}