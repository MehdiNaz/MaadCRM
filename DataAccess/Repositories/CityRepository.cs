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
        => await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId && x.CityStatus == Status.Show);

    public async ValueTask<City?> ChangeStatusCityByIdAsync(Status status, Ulid cityId)
    {
        try
        {
            var item = await _context.Cities!.FindAsync(cityId);
            if (item is null) return null;
            item.CityStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

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
            var customer = await _context.Cities.FindAsync(cityId);
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