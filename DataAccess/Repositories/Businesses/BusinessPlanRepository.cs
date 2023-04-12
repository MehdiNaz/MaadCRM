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
        => await _context.BusinessPlans!.OrderByDescending(o => o.BusinessPlansId).LastAsync(x => x.BusinessId == businessId);

    public async ValueTask<BusinessPlan?> GetBusinessPlansByIdAsync(Ulid businessPlansId)
        => await _context.BusinessPlans!.FirstOrDefaultAsync(x => x.BusinessPlansId == businessPlansId && x.BusinessPlansStatus == Status.Show);

    public async ValueTask<BusinessPlan?> ChangeStatusAsync(Status status, Ulid businessPlansId)
    {
        try
        {
            var item = await _context.BusinessPlans!.FindAsync(businessPlansId);
            if (item is null) return null;
            item.BusinessPlansStatus = status;
            await _context.SaveChangesAsync();
            return item;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlan?> CreateBusinessPlansAsync(BusinessPlan entity)
    {
        try
        {
            await _context.BusinessPlans!.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        catch
        {
            return null;
        }
    }


    public async ValueTask<BusinessPlan?> UpdateBusinessPlansAsync(BusinessPlan entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlan?> DeleteBusinessPlansAsync(Ulid businessPlansId)
    {
        try
        {
            var businessPlan = await GetBusinessPlansByIdAsync(businessPlansId);
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