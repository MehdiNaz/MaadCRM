namespace Application.Interfaces.Locations;

public interface ICountryRepository
{
    ValueTask<Result<ICollection<CountryResponse>>> GetAllCountriesAsync();
    ValueTask<Result<CountryResponse>> GetCityByIdAsync(Ulid countryId);
    //ValueTask<Country?> ChangeStatusCityByIdAsync(StatusType statusType, Ulid cityId);
    //ValueTask<Country?> CreateCityAsync(City? entity);
    //ValueTask<Country?> UpdateCityAsync(City entity, Ulid cityId);
    //ValueTask<Country?> DeleteCityAsync(Ulid cityId);
}
