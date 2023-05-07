namespace DataAccess.Repositories.Locations;

public class CityRepository : ICityRepository
{
    private readonly MaadContext _context;

    public CityRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<CityResponse>>> GetAllCitiesAsync()
    {
        try
        {
            return new Result<ICollection<CityResponse>>(await _context.Cities!.Where(x => x.CityStatus == Status.Show)
                .Include(x => x.IdProvinceNavigation)
                .Select(x => new CityResponse
                {
                    CityId = x.Id,
                    CityName = x.CityName,
                    DisplayOrder = x.DisplayOrder,
                    ProvinceId = x.IdProvinceNavigation.Id,
                    ProvinceName = x.IdProvinceNavigation.ProvinceName
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CityResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<CityResponse>> GetCityByIdAsync(Ulid cityId)
    {
        try
        {
            return new Result<CityResponse>(await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityId && x.CityStatus == Status.Show)
                .Select(x => new CityResponse
                {
                    CityId = x.Id,
                    CityName = x.CityName,
                    DisplayOrder = x.DisplayOrder
                }));
        }
        catch (Exception e)
        {
            return new Result<CityResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<CityResponse>>> ShowCitiesByIdProvinceAsync(Ulid cityId, Ulid provinceId)
    {
        try
        {
            return new Result<ICollection<CityResponse>>(await _context.Cities.Where(x => x.CityStatus == Status.Show)
                .Include(x => x.IdProvinceNavigation)
                .Where(x => x.IdProvince == provinceId)
                .Select(x => new CityResponse
                {
                    CityId = x.Id,
                    CityName = x.CityName,
                    ProvinceName = x.IdProvinceNavigation.ProvinceName,
                    DisplayOrder = x.DisplayOrder
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<CityResponse>>(new ValidationException(e.Message));
        }
    }

    //public async ValueTask<City?> ChangeStatusCityByIdAsync(Status status, Ulid cityId)
    //{
    //    try
    //    {
    //        var item = await _context.Cities!.FindAsync(cityId);
    //        if (item is null) return null;
    //        item.CityStatus = status;
    //        await _context.SaveChangesAsync();
    //        return item;
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    //public async ValueTask<City?> CreateCityAsync(City? entity)
    //{
    //    try
    //    {
    //        await _context.Cities!.AddAsync(entity!);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    //public async ValueTask<City?> UpdateCityAsync(City entity, Ulid cityId)
    //{
    //    try
    //    {
    //        _context.Update(entity);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}

    //public async ValueTask<City?> DeleteCityAsync(Ulid cityId)
    //{
    //    try
    //    {
    //        var customer = await _context.Cities.FindAsync(cityId);
    //        customer!.CityStatus = Status.Deleted;
    //        await _context.SaveChangesAsync();
    //        return customer;
    //    }
    //    catch
    //    {
    //        return null;
    //    }
    //}
}