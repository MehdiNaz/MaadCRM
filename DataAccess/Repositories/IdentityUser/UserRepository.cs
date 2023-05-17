namespace DataAccess.Repositories.IdentityUser;

public class UserRepository : IUserRepository
{
    private readonly MaadContext _context;

    public UserRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<User>>> GetAllUsersByBusinessIdAsync()
    {
        try
        {
            return (from user in _context.Users
                join business in _context.Businesses on user.IdBusiness equals business.Id
                select new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Family = user.Family,
                    IdBusiness = business.Id
                }).ToList();
        }
        catch (Exception e)
        {
            return new Result<ICollection<User>>(new ValidationException(e.Message));
        }
    }
}