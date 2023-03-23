namespace DataAccess.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly MaadContext _context;

    public PlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Plan?>> GetAllPlansAsync() => (await _context.Plans.ToListAsync())!;

    public async ValueTask<Plan?> GetPlansByIdAsync(int postId) => await _context.Plans.FindAsync(postId);

    public async ValueTask<Plan?> CreatePlanAsync(Plan? toCreate)
    {
        await _context.Plans!.AddAsync(toCreate);
        await _context.SaveChangesAsync();
        return toCreate;
    }

    public async ValueTask<Plan?> UpdatePlanAsync(string updateContent, int planId)
    {
        Plan? plan = await GetPlansByIdAsync(planId);
        _context.Update(plan);
        await _context.SaveChangesAsync();
        return plan;
    }

    public async ValueTask DeletePlanAsync(int planId)
    {
        Plan? plan = await GetPlansByIdAsync(planId);
        _context.Plans.Remove(plan);
        await _context.SaveChangesAsync();
    }
}