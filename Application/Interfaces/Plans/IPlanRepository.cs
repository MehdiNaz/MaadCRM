using Domain.Models.Businesses.Plans;

namespace Application.Interfaces.Plans;

public interface IPlanRepository
{
    ValueTask<ICollection<Plan?>> GetAllPlansAsync();
    ValueTask<Plan?> GetPlansByIdAsync(Ulid planId);
    ValueTask<Plan?> ChangeStatusPlansByIdAsync(ChangeStatusPlanCommand request);
    ValueTask<Plan?> CreatePlanAsync(CreatePlanCommand request);
    ValueTask<Plan?> UpdatePlanAsync(UpdatePlanCommand request);
    ValueTask<Plan?> DeletePlanAsync(DeletePlanCommand request);
}