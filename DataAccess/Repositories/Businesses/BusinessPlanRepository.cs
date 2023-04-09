namespace DataAccess.Repositories.Businesses;

public class BusinessPlanRepository : IBusinessPlanRepository
{
    private readonly MaadContext _context;

    public BusinessPlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<IReadOnlyList<BusinessPlans?>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId)
        => await _context.BusinessPlans!.Where(x => x.BusinessId == businessId).ToListAsync();

    public async ValueTask<IReadOnlyList<BusinessPlans?>> GetAllActivePlansAsync(Ulid businessId)
        => await _context.BusinessPlans!.Where(x => x.BusinessId == businessId && x.BusinessPlansStatus == Status.Show).ToListAsync();

    public async ValueTask<BusinessPlans?> GetTheLatestPlanAsync(Ulid businessId)
        => await _context.UsersPlans!.LastOrDefaultAsync(x => x.BusinessId == businessId);

    public async ValueTask<BusinessPlans?> GetBusinessPlansByIdAsync(Ulid businessId)
        => (await _context.BusinessPlans!.ToListAsync()).First(x => x.BusinessId == businessId);

    public async ValueTask<bool> ChangeStatusAsync(Status status, Ulid businessId)
    {
        try
        {
            Ulid currentBusiness = (await _context.BusinessPlans!.FirstAsync(x => x.BusinessPlansId == businessId))!.BusinessPlansId;
            bool result = (await _context.BusinessPlans!.SingleOrDefaultAsync(x => x.BusinessPlansId == currentBusiness))!.BusinessPlansStatus == status;
            if (!result) return false;
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask<BusinessPlans?> CreateBusinessPlansAsync(BusinessPlans entity)
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


    public async ValueTask<BusinessPlans?> UpdateBusinessPlansAsync(BusinessPlans entity)
    {
        try
        {
            var businessPlan = await GetBusinessPlansByIdAsync(entity.BusinessPlansId);
            _context.Update(businessPlan);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<BusinessPlans?> DeleteBusinessPlansAsync(Ulid businessPlansId)
    {
        try
        {
            var businessPlan = await GetBusinessPlansByIdAsync(businessPlansId);
            _context.BusinessPlans!.Remove(businessPlan);
            await _context.SaveChangesAsync();
            return businessPlan;
        }
        catch
        {
            return null;
        }
    }
}