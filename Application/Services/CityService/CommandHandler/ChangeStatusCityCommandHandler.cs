namespace Application.Services.CityService.CommandHandler;

public readonly struct ChangeStatusCityCommandHandler : IRequestHandler<ChangeStatusCityCommand, City?>
{
    private readonly ICityRepository _repository;

    public ChangeStatusCityCommandHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City?> Handle(ChangeStatusCityCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusCityByIdAsync(request.CityStatus, request.CityId);
}