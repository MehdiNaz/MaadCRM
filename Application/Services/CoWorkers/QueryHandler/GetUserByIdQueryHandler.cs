namespace Application.Services.CoWorkers.QueryHandler;

public readonly struct GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<TeamMateResponse>>
{
    private readonly ICoWorkerRepository _repository;

    public GetUserByIdQueryHandler(ICoWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCoworkerByIdAsync(request)).Match(result => new Result<TeamMateResponse>(result), exception => new Result<TeamMateResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(new Exception(e.Message));
        }
    }
}