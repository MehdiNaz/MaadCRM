namespace Application.Services.BusinessService.QueryHandler;

public readonly struct GetBusinessByUserIdQueryHandler : IRequestHandler<GetBusinessByUserIdQuery, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public GetBusinessByUserIdQueryHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(GetBusinessByUserIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetBusinessByUserIdAsync(request.UserId)).Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }
    }
}