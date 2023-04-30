namespace Application.Services.Locations.ProvinceService.QueryHandler;

public readonly struct ProvinceByIdHandler : IRequestHandler<GetProvinceByIdQuery, Result<ProvinceResponse>>
{
    private readonly IProvinceRepository _repository;

    public ProvinceByIdHandler(IProvinceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProvinceResponse>> Handle(GetProvinceByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetProvinceByIdAsync(request.ProvinceId))
                .Match(result => new Result<ProvinceResponse>(result),
                    exception => new Result<ProvinceResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProvinceResponse>(new Exception(e.Message));
        }
    }
}