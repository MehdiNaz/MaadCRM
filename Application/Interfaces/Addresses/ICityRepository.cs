namespace Application.Interfaces.Addresses;

public interface ICityRepository
{
    ValueTask<ICollection<City?>> GetAllCitiesAsync();
    ValueTask<City?> GetCityByIdAsync(Ulid cityId);
    ValueTask<City?> ChangeStatusCityByIdAsync(Status status, Ulid cityId);
    ValueTask<City?> CreateCityAsync(City? entity);
    ValueTask<City?> UpdateCityAsync(City entity, Ulid cityId);
    ValueTask<City?> DeleteCityAsync(Ulid cityId);
}