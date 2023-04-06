namespace DataAccess.Repositories.Plans;

public class UsersPlansRepository : IUsersPlansRepository
{
    private readonly MaadContext _context;

    public UsersPlansRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<ICollection<UsersPlans?>> GetAllActivePlansAsync()
        => (await _context.UsersPlans!.Where(x => x.UsersPlansStatus == Status.Show).ToListAsync())!;
    public async ValueTask<UsersPlans?> GetTheLatestPlanAsync()
        => await _context.UsersPlans!.LastOrDefaultAsync();

    public async ValueTask<ICollection<ResponseUsersPlans?>> GetUsersPlansByIdAsync(string usersId)
    {
        return (from up in _context.UsersPlans
                      join p in _context.Plans on up.UsersPlansId equals p.PlanId
                      where up.UserId == usersId
                      select new ResponseUsersPlans
                      {
                          Days = up.Days,
                          FinishDate = up.FinishDate,
                          KarbarCounts = up.KarbarCounts,
                          PlanName = p.PlanName,
                          Price = p.Price,
                          StartDate = up.StartDate,
                          UsersPlansId = up.UsersPlansId
                      }).ToList();
    }

    public async ValueTask<UsersPlans?> GetUsersPlansByIdAsync(Ulid usersPlansId)
        => await _context.UsersPlans!.SingleOrDefaultAsync(x => x.UsersPlansStatus == Status.Show);

    public async ValueTask<bool> ChangeStatusAsync(Status status, string usersId)
    {
        var currentUsersId = (await _context.UsersPlans!.SingleOrDefaultAsync(x => x.UserId == usersId))!.UserId;
        return (await _context.UsersPlans!.SingleOrDefaultAsync(x => x.UserId == currentUsersId))!.UsersPlansStatus == status;
    }

    public async ValueTask<UsersPlans?> CreateUsersPlansAsync(UsersPlans? entity)
    {
        try
        {
            await _context.UsersPlans!.AddAsync(entity!);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch
        {
            return null;
        }
    }

    public async ValueTask<UsersPlans?> UpdateUsersPlansAsync(UsersPlans entity, Ulid usersPlansId)
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

    public async ValueTask<UsersPlans?> DeleteUsersPlansAsync(Ulid usersPlansId)
    {
        try
        {
            var usersPlans = await GetUsersPlansByIdAsync(usersPlansId);
            usersPlans!.UsersPlansStatus = Status.Deleted;
            await _context.SaveChangesAsync();
            return usersPlans;
        }
        catch
        {
            return null;
        }
    }
}