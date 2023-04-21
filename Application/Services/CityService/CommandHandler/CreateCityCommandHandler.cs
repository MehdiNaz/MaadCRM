namespace Application.Services.CityService.CommandHandler;

public readonly struct CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
{
    private readonly ICityRepository _repository;

    public CreateCityCommandHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        City item = new()
        {
            CityName = request.CityName,
            IsDefault = request.IsDefault,
            DisplayOrder = request.DisplayOrder,
            IdProvince = request.ProvinceId
        };
        await _repository.CreateCityAsync(item);
        return item;
    }
}
