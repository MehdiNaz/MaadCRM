namespace DataAccess.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly MaadContext _context;

    public PlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Plan?>> GetAllPlansAsync()
        => (await _context.Plans.Where(x => x.PlanStatus == Status.Show).ToListAsync())!;

    public async ValueTask<Plan?> GetPlansByIdAsync(Ulid postId) => await _context.Plans.FindAsync(postId);

    public async ValueTask<Plan?> CreatePlanAsync(Plan? toCreate)
    {
        try
        {
            await _context.Plans!.AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Plan?> UpdatePlanAsync(Plan entity, Ulid planId)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        catch (Exception)
        {
            return null;
        }
    }

    public async ValueTask<Plan?> DeletePlanAsync(Ulid planId)
    {
        try
        {
            Plan? plan = await GetPlansByIdAsync(planId);
            _context.Plans.Remove(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
        catch
        {
            return null;
        }
    }
}