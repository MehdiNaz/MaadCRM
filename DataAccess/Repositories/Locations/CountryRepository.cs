namespace DataAccess.Repositories.Locations;

public class CountryRepository : ICountryRepository
{
    private readonly MaadContext _context;

    public CountryRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CountryResponse>>> GetAllCountriesAsync()
    {
        try
        {
            return new Result<ICollection<CountryResponse>>(await _context.Countries.Where(x => x.CountryStatus == Status.Show)
                .Select(x => new CountryResponse()
                {
                    CountryId = x.Id,
                    CountryName = x.CountryName,
                    DisplayOrder = x.DisplayOrder
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CountryResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CountryResponse>> GetCityByIdAsync(Ulid countryId)
    {
        try
        {
            return new Result<CountryResponse>(await _context.Countries.FirstOrDefaultAsync(x => x.Id == countryId && x.CountryStatus == Status.Show)
                .Select(x => new CountryResponse()
                {
                    CountryId = x.Id,
                    CountryName = x.CountryName,
                    DisplayOrder = x.DisplayOrder
                }));
        }
        catch (Exception e)
        {
            return new Result<CountryResponse>(new ValidationException(e.Message));
        }
    }
}
