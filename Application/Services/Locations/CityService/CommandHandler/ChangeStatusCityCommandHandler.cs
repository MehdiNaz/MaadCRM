namespace Application.Services.Locations.CityService.CommandHandler;

public readonly struct ChangeStatusCityCommandHandler : IRequestHandler<ChangeStatusCityCommand, Result<City>>
{
    private readonly ICityRepository _repository;

    public ChangeStatusCityCommandHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<City>> Handle(ChangeStatusCityCommand request, CancellationToken cancellationToken)
    {
        return null;
        //try
        //{
        //    return (await _repository.ChangeStatusCityByIdAsync(request.CityStatus, request.CityId))
        //        .Match(result => new Result<City>(result),
        //        exception => new Result<City>(exception));
        //}
        //catch (Exception e)
        //{
        //    return new Result<City>(new Exception(e.Message));
        //}
    }
}