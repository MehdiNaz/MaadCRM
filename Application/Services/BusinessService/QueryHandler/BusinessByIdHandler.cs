namespace Application.Services.BusinessService.QueryHandler;

public readonly struct BusinessByIdHandler : IRequestHandler<BusinessByIdQuery, Result<Business>>
{
    private readonly IBusinessRepository _repository;

    public BusinessByIdHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Business>> Handle(BusinessByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetBusinessByIdAsync(request.BusinessId)).Match(result => new Result<Business>(result), exception => new Result<Business>(exception));
        }
        catch (Exception e)
        {
            return new Result<Business>(new Exception(e.Message));
        }

    }
}