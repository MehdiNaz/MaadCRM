namespace Application.Services.CoWorkers.QueryHandler;

public readonly struct AllUserQueryHandler : IRequestHandler<AllUsersQuery, Result<ICollection<TeamMateResponse>>>
{
    private readonly ICoWorkerRepository _repository;

    public AllUserQueryHandler(ICoWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<TeamMateResponse>>> Handle(AllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCoworkerAsync(request)).Match(
                result => new Result<ICollection<TeamMateResponse>>(result), 
                exception => new Result<ICollection<TeamMateResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateResponse>>(new Exception(e.Message));
        }
    }
}