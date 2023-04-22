namespace Application.Services.BusinessService.QueryHandler;

public readonly struct AllBusinessHandler : IRequestHandler<AllBusinessQuery, Result<ICollection<Business>>>
{
    private readonly IBusinessRepository _repository;

    public AllBusinessHandler(IBusinessRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<Business>>> Handle(AllBusinessQuery request, CancellationToken cancellationToken)
    {

        try
        {
            return (await _repository.GetAllBusinessesAsync()).Match(result => new Result<ICollection<Business>>(result), exception => new Result<ICollection<Business>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<Business>>(new Exception(e.Message));
        }
    }
}