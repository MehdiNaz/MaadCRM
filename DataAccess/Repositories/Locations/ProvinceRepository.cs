namespace DataAccess.Repositories.Locations;

public class ProvinceRepository : IProvinceRepository
{
    private readonly MaadContext _context;

    public ProvinceRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<ProvinceResponse>>> GetAllProvincesAsync()
    {
        try
        {
            return new Result<ICollection<ProvinceResponse>>(await _context.Provinces.Where(x => x.ProvinceStatusType == StatusType.Show)
                .Select(x => new ProvinceResponse
                {
                    IdProvince = x.Id,
                    ProvinceName = x.ProvinceName,
                    DisplayOrder = x.DisplayOrder
                }).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<ProvinceResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ProvinceResponse>> GetProvinceByIdAsync(Ulid provinceId)
    {
        try
        {
            return new Result<ProvinceResponse>(await _context.Provinces.FirstOrDefaultAsync(x => x.Id == provinceId && x.ProvinceStatusType == StatusType.Show)
                .Select(x => new ProvinceResponse()
                {
                    IdProvince = x.Id,
                    ProvinceName = x.ProvinceName,
                    DisplayOrder = x.DisplayOrder
                }));
        }
        catch (Exception e)
        {
            return new Result<ProvinceResponse>(new ValidationException(e.Message));
        }
    }
}
