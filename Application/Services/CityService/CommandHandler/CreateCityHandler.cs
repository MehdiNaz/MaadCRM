namespace Application.Services.CityService.CommandHandler;

public class CreateCityHandler : IRequestHandler<CreateCityCommand, City>
{
    private readonly ICityRepository _repository;

    public CreateCityHandler(ICityRepository repository)
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
            ProvinceId = request.ProvinceId,
            CustomerId = request.CustomerId
        };
        await _repository.CreateCityAsync(item);
        return item;
    }
}
