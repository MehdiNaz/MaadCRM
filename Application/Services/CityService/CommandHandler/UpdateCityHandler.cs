namespace Application.Services.CityService.CommandHandler;

public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, City>
{
    private readonly ICityRepository _repository;

    public UpdateCityHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        City item = new()
        {
            CityName = request.CityName,
            IsDefault = request.IsDefault,
            DisplayOrder = request.DisplayOrder,
            ProvinceId = request.ProvinceId,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateCityAsync(item, request.CityId);
        return item;
    }
}