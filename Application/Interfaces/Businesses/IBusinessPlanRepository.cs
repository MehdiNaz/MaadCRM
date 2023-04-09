namespace Application.Interfaces.Businesses;

public interface IBusinessPlanRepository
{
    ValueTask<IReadOnlyList<BusinessPlans?>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId);
    ValueTask<IReadOnlyList<BusinessPlans?>> GetAllActivePlansAsync(Ulid businessId);
    ValueTask<BusinessPlans?> GetTheLatestPlanAsync(Ulid businessId);
    ValueTask<BusinessPlans?> GetBusinessPlansByIdAsync(Ulid businessId);
    ValueTask<bool> ChangeStatusAsync(Status status, Ulid businessId);
    ValueTask<BusinessPlans?> CreateBusinessPlansAsync(BusinessPlans entity);
    ValueTask<BusinessPlans?> UpdateBusinessPlansAsync(BusinessPlans entity);
    ValueTask<BusinessPlans?> DeleteBusinessPlansAsync(Ulid businessPlansId);
}