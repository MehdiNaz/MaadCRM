namespace DataAccess.Repositories.Plans;

public class PlanRepository : IPlanRepository
{
    private readonly MaadContext _context;

    public PlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Plan?>> GetAllPlansAsync()
        => await _context.Plans.Where(x => x.PlanStatus == Status.Show).ToListAsync()!;

    public async ValueTask<Plan?> GetPlansByIdAsync(Ulid postId)
        => await _context.Plans.FirstOrDefaultAsync(x => x.PlanId == postId && x.PlanStatus == Status.Show);

    public async ValueTask<Plan?> ChangeStatusPlansByIdAsync(Status status, Ulid planId)
    {
        try
        {
            var item = await _context.Plans!.FindAsync(planId);
            if (item is null) return null;
            item.PlanStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Plan?> CreatePlanAsync(Plan? toCreate)
    {
        try
        {
            toCreate.FinalPrice = toCreate.CountOfUsers * toCreate.PriceOfUsers + toCreate.CountOfDay * toCreate.PriceOfDay;
            await _context.Plans!.AddAsync(toCreate);
            await _context.SaveChangesAsync();
            return toCreate;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Plan?> UpdatePlanAsync(Plan entity)
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
            //_context.Plans.Remove(plan);
            plan.PlanStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return plan;
        }
        catch
        {
            return null;
        }
    }
}