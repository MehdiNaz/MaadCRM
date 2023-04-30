namespace Application.Interfaces.Locations;

public interface IProvinceRepository
{
    ValueTask<Result<ICollection<ProvinceResponse>>> GetAllProvincesAsync();
    ValueTask<Result<ProvinceResponse>> GetProvinceByIdAsync(Ulid provinceId);
}
