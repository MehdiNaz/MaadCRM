namespace Application.Interfaces;

public interface IBusinessRepository
{
    ValueTask<ICollection<Business?>> GetAllBusinessesAsync();
    ValueTask<Business?> GetBusinessByIdAsync(int businessId);
    ValueTask<Business?> CreateBusinessAsync(Business? toCreate);
    ValueTask<Business?> UpdateBusinessAsync(string updateContent, int businessId);
    ValueTask DeleteBusinessAsync(int businessId);
}