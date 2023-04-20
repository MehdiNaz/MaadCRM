namespace Application.Interfaces.Businesses;

public interface IBusinessRepository
{
    ValueTask<IReadOnlyList<Business?>> GetAllBusinessesAsync();
    ValueTask<Business?> GetBusinessByIdAsync(Ulid businessId);
    ValueTask<Business?> ChangeStatsAsync(ChangeStatusBusinessCommand request);
    ValueTask<Business?> CreateBusinessAsync(CreateBusinessCommand request);
    ValueTask<Business?> UpdateBusinessAsync(UpdateBusinessCommand request);
    ValueTask<Business?> DeleteBusinessAsync(DeleteBusinessCommand request);
}