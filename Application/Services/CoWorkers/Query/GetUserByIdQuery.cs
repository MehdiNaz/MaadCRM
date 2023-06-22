namespace Application.Services.CoWorkers.Query;

public struct GetUserByIdQuery : IRequest<Result<TeamMateResponse>>
{
    public string Id { get; set; }
    public string IdUser { get; set; }
}