namespace Application.Interfaces.Businesses;

public interface IBusinessPlanRepository
{
    ValueTask<IReadOnlyList<BusinessPlan?>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId);
    ValueTask<IReadOnlyList<BusinessPlan?>> GetAllActivePlansAsync(Ulid businessId);
    ValueTask<BusinessPlan?> GetTheLatestPlanAsync(Ulid businessId);
    ValueTask<BusinessPlan?> GetBusinessPlansByIdAsync(Ulid businessPlansId);
    ValueTask<BusinessPlan?> ChangeStatusAsync(Status status, Ulid businessPlansId);
    ValueTask<BusinessPlan?> CreateBusinessPlansAsync(BusinessPlan entity);
    ValueTask<BusinessPlan?> UpdateBusinessPlansAsync(BusinessPlan entity);
    ValueTask<BusinessPlan?> DeleteBusinessPlansAsync(Ulid businessPlansId);
}