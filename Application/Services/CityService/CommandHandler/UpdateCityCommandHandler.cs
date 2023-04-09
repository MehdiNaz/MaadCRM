namespace Application.Services.CityService.CommandHandler;

public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, City>
{
    private readonly ICityRepository _repository;

    public UpdateCityCommandHandler(ICityRepository repository)
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
            ProvinceId = request.ProvinceId
        };
        await _repository.UpdateCityAsync(item, request.CityId);
        return item;
    }
}