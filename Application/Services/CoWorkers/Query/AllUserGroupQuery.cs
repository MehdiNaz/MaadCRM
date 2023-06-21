namespace Application.Services.CoWorkers.Query;

public struct AllUserGroupsQuery : IRequest<Result<ICollection<TeamMateGroupRespnse>>>
{
    public Ulid Id { get; set; }
    public string IdUser { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
    public string? Sort { get; set; }
    public string? SortDirection { get; set; }
}