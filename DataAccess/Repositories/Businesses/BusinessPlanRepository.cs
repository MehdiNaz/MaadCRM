﻿namespace DataAccess.Repositories.Businesses;

public class BusinessPlanRepository : IBusinessPlanRepository
{
    private readonly MaadContext _context;

    public BusinessPlanRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<BusinessPlan>>> GetAllBusinessPlansByBusinessIdAsync(Ulid businessId)
    {
        try
        {
            return new Result<ICollection<BusinessPlan>>(await _context.BusinessPlans.Where(x => x.IdBusiness == businessId).ToListAsync());
        }
        catch (Exception e)
        {
            return new Result<ICollection<BusinessPlan>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<BusinessPlan>>> GetAllActivePlansAsync(Ulid businessId)
    {

        try
        {
            return await _context.BusinessPlans.Where(x => x.IdBusiness == businessId && x.Status == StatusType.Show).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<BusinessPlan>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> GetTheLatestPlanAsync(Ulid businessId)
    {
        try
        {
            return await _context.BusinessPlans.OrderByDescending(o => o.Id).LastAsync(x => x.IdBusiness == businessId);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> GetBusinessPlansByIdAsync(Ulid businessPlansId)
    {
        try
        {
            return await _context.BusinessPlans.FirstOrDefaultAsync(x => x.Id == businessPlansId && x.Status == StatusType.Show);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> ChangeStatusAsync(ChangeStatusBusinessPlansQuery request)
    {
        try
        {
            BusinessPlan businessPlan = new()
            {
                IdBusiness = request.BusinessPlansId
            };

            var item = await _context.BusinessPlans!.FindAsync(businessPlan);
            if (item is null) return new Result<BusinessPlan>(new ValidationException(ResultErrorMessage.NotFound));
            item.Status = request.StatusType;
            await _context.SaveChangesAsync();
            return new Result<BusinessPlan>(item);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> CreateBusinessPlansAsync(CreateBusinessPlansCommand entity)
    {
        try
        {
            BusinessPlan item = new()
            {
                IdPlan = entity.PlanId,
                IdBusiness = entity.BusinessId,
                CountOfDay = entity.CountOfDay,
                CountOfUsers = entity.CountOfUsers
            };
            await _context.BusinessPlans!.AddAsync(item);
            await _context.SaveChangesAsync();
            return new Result<BusinessPlan>(item);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> UpdateBusinessPlansAsync(UpdateBusinessPlansCommand request)
    {
        try
        {
            BusinessPlan item = await _context.BusinessPlans.FindAsync(request.BusinessPlansId);

            item.IdPlan = request.PlanId;
            item.IdBusiness = request.BusinessId;
            item.CountOfDay = request.CountOfDay;
            item.CountOfUsers = request.CountOfUsers;


            _context.Update(item);
            await _context.SaveChangesAsync();
            return new Result<BusinessPlan>(item);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<BusinessPlan>> DeleteBusinessPlansAsync(Ulid id)
    {
        try
        {
            var businessPlan = await _context.BusinessPlans.FindAsync(id);
            businessPlan.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();
            return new Result<BusinessPlan>(businessPlan);
        }
        catch (Exception e)
        {
            return new Result<BusinessPlan>(new ValidationException(e.Message));
        }
    }
}