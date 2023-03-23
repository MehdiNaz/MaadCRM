namespace Application.Interfaces;

public interface IPlanRepository
{
    Task<ICollection<Plan?>> GetAllPlansAsync();
    ValueTask<Plan?> GetPlansByIdAsync(int postId);
    ValueTask<Plan?> CreatePlanAsync(Plan? toCreate);
    ValueTask<Plan?> UpdatePlanAsync(string updateContent, int planId);
    ValueTask DeletePlanAsync(int planId);
}