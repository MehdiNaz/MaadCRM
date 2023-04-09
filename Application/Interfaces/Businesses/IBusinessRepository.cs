namespace Application.Interfaces.Businesses;

public interface IBusinessRepository
{
    ValueTask<IReadOnlyList<Business?>> GetAllBusinessesAsync();
    ValueTask<Business?> GetBusinessByIdAsync(Ulid businessId);
    ValueTask<Business?> CreateBusinessAsync(Business? entity);
    ValueTask<Business?> UpdateBusinessAsync(Business entity);
    ValueTask<Business?> DeleteBusinessAsync(Ulid businessId);
}