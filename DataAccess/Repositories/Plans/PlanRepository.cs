namespace DataAccess.Repositories.Plans;

public class PlanRepository : IPlanRepository
{
    private readonly MaadContext _context;

    public PlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<Plan?>> GetAllPlansAsync()
        => await _context.Plans.Where(x => x.Status == StatusType.Show).ToListAsync()!;

    public async ValueTask<Plan?> GetPlansByIdAsync(Ulid postId)
        => await _context.Plans.FirstOrDefaultAsync(x => x.Id == postId && x.Status == StatusType.Show);

    public async ValueTask<Plan?> ChangeStatusPlansByIdAsync(ChangeStatusPlanCommand request)
    {
        try
        {
            var item = await _context.Plans!.FindAsync(request.PlanId);
            if (item is null) return null;
            item.Status = request.PlanStatusType;
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
                Title = request.PlanName,
                CountOfUsers = request.CountOfUsers,
                PriceOfEachUsers = request.PriceOfUsers,
                CountOfDay = request.CountOfDay,
                PriceOfEachDay = request.PriceOfDay,
                // TODO: UserId , PriceFinal
                // UserId = request.UserId,
                // PriceFinal = request.CountOfUsers * request.PriceOfUsers + request.CountOfDay * request.PriceOfDay
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
            var plan = await _context.Plans.FindAsync(request.Id);
            plan.Title = request.PlanName;
            plan.CountOfUsers = request.CountOfUsers;
            plan.PriceOfEachUsers = request.PriceOfUsers;
            plan.CountOfDay = request.CountOfDay;
            plan.PriceOfEachDay = request.PriceOfDay;
            // TODO: UserId , PriceFinal
            // plan.UserId = request.UserId;
            // plan.PriceFinal = request.CountOfUsers * request.PriceOfUsers + request.CountOfDay * request.PriceOfDay;
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
            var plan = await _context.Plans.FindAsync(id);
            plan.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return plan;
        }
        catch
        {
            return null;
        }
    }
}