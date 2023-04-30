namespace Application.Services.Locations.ProvinceService.QueryHandler;

public readonly struct GetAllProvinceHandler : IRequestHandler<GetAllProvincesQuery, Result<ICollection<ProvinceResponse>>>
{
    private readonly IProvinceRepository _repository;

    public GetAllProvinceHandler(IProvinceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ProvinceResponse>>> Handle(GetAllProvincesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllProvincesAsync())
                .Match(result => new Result<ICollection<ProvinceResponse>>(result),
                    exception => new Result<ICollection<ProvinceResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProvinceResponse>>(new Exception(e.Message));
        }
    }
}