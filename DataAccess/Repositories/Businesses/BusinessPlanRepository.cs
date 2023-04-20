namespace DataAccess.Repositories.Businesses;

public class BusinessPlanRepository : IBusinessPlanRepository
{
    private readonly MaadContext _context;

    public BusinessPlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<IReadOnlyList<BusinessPlan?>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId)
        => await _context.BusinessPlans!.Where(x => x.BusinessId == businessId).ToListAsync();

    public async ValueTask<IReadOnlyList<BusinessPlan?>> GetAllActivePlansAsync(Ulid businessId)
        => await _context.BusinessPlans!.Where(x => x.BusinessId == businessId && x.BusinessPlansStatus == Status.Show).ToListAsync();

    public async ValueTask<BusinessPlan?> GetTheLatestPlanAsync(Ulid businessId)
        => await _context.BusinessPlans!.OrderByDescending(o => o.Id).LastAsync(x => x.BusinessId == businessId);

    public async ValueTask<BusinessPlan?> GetBusinessPlansByIdAsync(Ulid businessPlansId)
        => await _context.BusinessPlans!.FirstOrDefaultAsync(x => x.Id == businessPlansId && x.BusinessPlansStatus == Status.Show);

    public async ValueTask<BusinessPlan?> ChangeStatusAsync(ChangeStatusBusinessPlansQuery request)
    {
        try
        {
            BusinessPlan businessPlan = new()
            {
                BusinessId = request.BusinessPlansId
            };

            var item = await _context.BusinessPlans!.FindAsync(businessPlan);
            if (item is null) return null;
            item.BusinessPlansStatus = request.Status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlan?> CreateBusinessPlansAsync(CreateBusinessPlansCommand entity)
    {
        try
        {
            BusinessPlan item = new()
            {
                PlanId = entity.PlanId,
                BusinessId = entity.BusinessId,
                CountOfDay = entity.CountOfDay,
                CountOfUsers = entity.CountOfUsers
            };
            await _context.BusinessPlans!.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlan?> UpdateBusinessPlansAsync(UpdateBusinessPlansCommand request)
    {
        try
        {
            BusinessPlan businessPlan = new()
            {
                Id = request.BusinessPlansId,
                PlanId = request.PlanId,
                BusinessId = request.BusinessId,
                CountOfDay = request.CountOfDay,
                CountOfUsers = request.CountOfUsers
            };

            _context.Update(businessPlan);
            await _context.SaveChangesAsync();
            return businessPlan;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlan?> DeleteBusinessPlansAsync(DeleteBusinessPlansCommand request)
    {
        try
        {
            var businessPlan = await GetBusinessPlansByIdAsync(request.BusinessPlansId);
            // _context.BusinessPlans!.Remove(businessPlan);
            businessPlan.BusinessPlansStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return businessPlan;
        }
        catch
        {
            return null;
        }
    }
}