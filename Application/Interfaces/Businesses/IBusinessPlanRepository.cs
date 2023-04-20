namespace Application.Interfaces.Businesses;

public interface IBusinessPlanRepository
{
    ValueTask<IReadOnlyList<BusinessPlan?>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId);
    ValueTask<IReadOnlyList<BusinessPlan?>> GetAllActivePlansAsync(Ulid businessId);
    ValueTask<BusinessPlan?> GetTheLatestPlanAsync(Ulid businessId);
    ValueTask<BusinessPlan?> GetBusinessPlansByIdAsync(Ulid businessPlansId);
    ValueTask<BusinessPlan?> ChangeStatusAsync(ChangeStatusBusinessPlansQuery request);
    ValueTask<BusinessPlan?> CreateBusinessPlansAsync(CreateBusinessPlansCommand request);
    ValueTask<BusinessPlan?> UpdateBusinessPlansAsync(UpdateBusinessPlansCommand request);
    ValueTask<BusinessPlan?> DeleteBusinessPlansAsync(DeleteBusinessPlansCommand request);
}