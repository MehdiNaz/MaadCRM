namespace DataAccess.Repositories;

public class CityRepository : ICityRepository
{
    private readonly MaadContext _context;

    public CityRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<City?>> GetAllCitiesAsync()
        => await _context.Cities!.Where(x => x.CityStatus == Status.Show).ToListAsync();

    public async ValueTask<City?> GetCityByIdAsync(Ulid cityId)
        => await _context.Cities.FindAsync(cityId);

    public async ValueTask<City?> CreateCityAsync(City? entity)
    {
        try
        {
            await _context.Cities!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<City?> UpdateCityAsync(City entity, Ulid cityId)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<City?> DeleteCityAsync(Ulid cityId)
    {
        try
        {
            var customer = await GetCityByIdAsync(cityId);
            customer!.CityStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return customer;
        }
        catch
        {
            return null;
        }
    }
}