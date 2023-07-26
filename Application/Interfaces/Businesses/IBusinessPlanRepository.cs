using Domain.Models.Businesses.Plans;

namespace Application.Interfaces.Businesses;

public interface IBusinessPlanRepository
{
    ValueTask<Result<ICollection<BusinessPlan?>>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId);
    ValueTask<Result<ICollection<BusinessPlan?>>> GetAllActivePlansAsync(Ulid businessId);
    ValueTask<Result<BusinessPlan>> GetTheLatestPlanAsync(Ulid businessId);
    ValueTask<Result<BusinessPlan>> GetBusinessPlansByIdAsync(Ulid businessPlansId);
    ValueTask<Result<BusinessPlan>> ChangeStatusAsync(ChangeStatusBusinessPlansQuery request);
    ValueTask<Result<BusinessPlan>> CreateBusinessPlansAsync(CreateBusinessPlansCommand request);
    ValueTask<Result<BusinessPlan>> UpdateBusinessPlansAsync(UpdateBusinessPlansCommand request);
    ValueTask<Result<BusinessPlan>> DeleteBusinessPlansAsync(Ulid id);
}