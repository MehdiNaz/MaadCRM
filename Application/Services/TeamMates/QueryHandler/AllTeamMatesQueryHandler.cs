using Application.Services.TeamMates.Query;

namespace Application.Services.TeamMates.QueryHandler;

public readonly struct AllUserQueryHandler : IRequestHandler<AllUsersQuery, Result<ICollection<TeamMateResponse>>>
{
    private readonly ITeamMateRepository _repository;

    public AllUserQueryHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<TeamMateResponse>>> Handle(AllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllTeamMatesAsync(request)).Match(
                result => new Result<ICollection<TeamMateResponse>>(result), 
                exception => new Result<ICollection<TeamMateResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateResponse>>(new Exception(e.Message));
        }
    }
}