namespace Application.Services.CityService.CommandHandler;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
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
            ProvinceId = request.ProvinceId,
            CustomerId = request.CustomerId
        };
        await _repository.CreateCityAsync(item);
        return item;
    }
}
