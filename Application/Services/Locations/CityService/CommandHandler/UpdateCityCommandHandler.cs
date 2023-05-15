namespace Application.Services.Locations.CityService.CommandHandler;

public readonly struct UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, City>
{
    private readonly ICityRepository _repository;

    public UpdateCityCommandHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        return null;
        //City item = new()
        //{
        //    CityName = request.CityName,
        //    IsDefault = request.IsDefault,
        //    DisplayOrder = request.DisplayOrder,
        //    IdProvince = request.IdProvince
        //};
        //await _repository.UpdateCityAsync(item, request.IdCity);
        //return item;
    }
}