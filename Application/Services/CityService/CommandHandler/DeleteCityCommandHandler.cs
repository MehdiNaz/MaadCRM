namespace Application.Services.CityService.CommandHandler;

public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, City>
{
    private readonly ICityRepository _repository;

    public DeleteCityCommandHandler(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCityAsync(request.CityId))!;
}