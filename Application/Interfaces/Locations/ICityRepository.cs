using Application.Responses.Location;

namespace Application.Interfaces.Locations;

public interface ICityRepository
{
    ValueTask<Result<ICollection<CityResponse>>> GetAllCitiesAsync();
    ValueTask<Result<CityResponse>> GetCityByIdAsync(Ulid cityId);
    ValueTask<Result<ICollection<CityResponse>>> ShowCitiesByIdProvinceAsync(Ulid cityId,Ulid provinceId);
}