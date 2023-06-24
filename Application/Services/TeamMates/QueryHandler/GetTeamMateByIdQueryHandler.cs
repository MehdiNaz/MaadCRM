using Application.Services.TeamMates.Query;

namespace Application.Services.TeamMates.QueryHandler;

public readonly struct GetTeamMateByIdQueryHandler : IRequestHandler<GetTeamMateByIdQuery, Result<TeamMateResponse>>
{
    private readonly ITeamMateRepository _repository;

    public GetTeamMateByIdQueryHandler(ITeamMateRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<TeamMateResponse>> Handle(GetTeamMateByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetTeamMateByIdAsync(request)).Match(result => new Result<TeamMateResponse>(result), exception => new Result<TeamMateResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(new Exception(e.Message));
        }
    }
}