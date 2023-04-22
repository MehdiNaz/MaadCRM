namespace Application.Interfaces.Businesses;

public interface IBusinessRepository
{
    ValueTask<Result<ICollection<Business>>> GetAllBusinessesAsync();
    ValueTask<Result<Business>> GetBusinessByIdAsync(Ulid businessId);
    ValueTask<Result<Business>> ChangeStatsAsync(ChangeStatusBusinessCommand request);
    ValueTask<Result<Business>> CreateBusinessAsync(CreateBusinessCommand request);
    ValueTask<Result<Business>> UpdateBusinessAsync(UpdateBusinessCommand request);
    ValueTask<Result<Business>> DeleteBusinessAsync(DeleteBusinessCommand request);
}