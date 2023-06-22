namespace Application.Services.CoWorkers.QueryHandler;

public readonly struct GetUserGroupByIdQueryHandler : IRequestHandler<GetUserGroupByIdQuery, Result<TeamMateGroupResponse>>
{
    private readonly ICoWorkerGroupRepository _repository;

    public GetUserGroupByIdQueryHandler(ICoWorkerGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateGroupResponse>> Handle(GetUserGroupByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetUserGroupById(request)).Match(result => new Result<TeamMateGroupResponse>(result), exception => new Result<TeamMateGroupResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(new Exception(e.Message));
        }
    }
}