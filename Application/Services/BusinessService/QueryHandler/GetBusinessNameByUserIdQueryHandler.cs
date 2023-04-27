namespace Application.Services.BusinessService.QueryHandler;

public readonly struct GetBusinessNameByUserIdQueryHandler : IRequestHandler<GetBusinessNameByUserIdQuery, Result<ICollection<Business>>>
{
    private readonly IBusinessRepository _repository;

    public GetBusinessNameByUserIdQueryHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<Business>>> Handle(GetBusinessNameByUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetBusinessNameByUserId(request.UserId)).Match(result => new Result<ICollection<Business>>(result), exception => new Result<ICollection<Business>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<Business>>(new Exception(e.Message));
        }
    }
}