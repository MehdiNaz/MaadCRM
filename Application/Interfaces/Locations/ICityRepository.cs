using Application.Responses.Location;

namespace Application.Interfaces.Locations;

public interface ICityRepository
{
    ValueTask<Result<ICollection<CityResponse>>> GetAllCitiesAsync();
    ValueTask<Result<CityResponse>> GetCityByIdAsync(Ulid cityId);
    ValueTask<Result<ICollection<CityResponse>>> ShowCitiesByIdProvinceAsync(Ulid cityId,Ulid provinceId);
    //ValueTask<City?> ChangeStatusCityByIdAsync(StatusType statusType, Ulid cityId);
    //ValueTask<City?> CreateCityAsync(City? entity);
    //ValueTask<City?> UpdateCityAsync(City entity, Ulid cityId);
    //ValueTask<City?> DeleteCityAsync(Ulid cityId);
}