namespace DataAccess.Repositories.IdentityUser;

public class UserRepository : IUserRepository
{
    private readonly MaadContext _context;

    public UserRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<UserResponse>>> GetAllUsersByBusinessIdAsync(Ulid businessId)
    {
        try
        {
            return await (from user in _context.Users
                join business in _context.Businesses on user.IdBusiness equals business.Id
                select new UserResponse
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Family = user.Family,
                    IdBusiness = business.Id,
                    Gender = user.Gender,
                    BusinessName = business.BusinessName,
                    CodeMelli = user.CodeMelli,
                    Address = user.Address,
                    CreatedOn = user.CreatedOn,
                    DateOfBirth = user.DateOfBirth,
                    Flag = user.Flag,
                    Married = user.Married,
                    LastIp = user.LastIp,
                    LastLogin = user.LastLogin
                }).ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<UserResponse>>(new ValidationException(e.Message));
        }
    }
}