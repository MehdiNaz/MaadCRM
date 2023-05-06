namespace DataAccess.Repositories.Plans;

public class PlanRepository : IPlanRepository
{
    private readonly MaadContext _context;

    public PlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Plan?>> GetAllPlansAsync()
        => await _context.Plans.Where(x => x.StatusPlan == Status.Show).ToListAsync()!;

    public async ValueTask<Plan?> GetPlansByIdAsync(Ulid postId)
        => await _context.Plans.FirstOrDefaultAsync(x => x.Id == postId && x.StatusPlan == Status.Show);

    public async ValueTask<Plan?> ChangeStatusPlansByIdAsync(ChangeStatusPlanCommand request)
    {
        try
        {
            var item = await _context.Plans!.FindAsync(request.PlanId);
            if (item is null) return null;
            item.StatusPlan = request.PlanStatus;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Plan?> CreatePlanAsync(CreatePlanCommand request)
    {
        try
        {
            Plan plan = new()
            {
                PlanName = request.PlanName,
                CountOfUsers = request.CountOfUsers,
                PriceOfUsers = request.PriceOfUsers,
                CountOfDay = request.CountOfDay,
                PriceOfDay = request.PriceOfDay,
                UserId = request.UserId,
                PriceFinal = request.CountOfUsers * request.PriceOfUsers + request.CountOfDay * request.PriceOfDay
            };

            await _context.Plans!.AddAsync(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<Plan?> UpdatePlanAsync(UpdatePlanCommand request)
    {
        try
        {
            Plan plan = await _context.Plans.FindAsync(request.Id);
            plan.PlanName = request.PlanName;
            plan.CountOfUsers = request.CountOfUsers;
            plan.PriceOfUsers = request.PriceOfUsers;
            plan.CountOfDay = request.CountOfDay;
            plan.PriceOfDay = request.PriceOfDay;
            plan.UserId = request.UserId;
            plan.PriceFinal = request.CountOfUsers * request.PriceOfUsers + request.CountOfDay * request.PriceOfDay;
            _context.Update(plan);
            await _context.SaveChangesAsync();
            return plan;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async ValueTask<Plan?> DeletePlanAsync(Ulid id)
    {
        try
        {
            Plan? plan = await _context.Plans.FindAsync(id);
            //_context.Plans.Remove(plan);
            plan.StatusPlan = Status.Deleted;
            await _context.SaveChangesAsync();
            return plan;
        }
        catch
        {
            return null;
        }
    }
}