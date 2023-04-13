namespace Application.Interfaces.Plans;

public interface IPlanRepository
{
    ValueTask<ICollection<Plan?>> GetAllPlansAsync();
    ValueTask<Plan?> GetPlansByIdAsync(Ulid planId);
    ValueTask<Plan?> ChangeStatusPlansByIdAsync(Status status, Ulid planId);
    ValueTask<Plan?> CreatePlanAsync(Plan? entity);
    ValueTask<Plan?> UpdatePlanAsync(Plan entity);
    ValueTask<Plan?> DeletePlanAsync(Ulid planId);
}