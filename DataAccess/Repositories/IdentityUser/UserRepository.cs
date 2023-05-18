namespace DataAccess.Repositories.IdentityUser;

public class UserRepository : IUserRepository
{
    private readonly MaadContext _context;

    public UserRepository(MaadContext context)
    {
        _context = context;
    }

    public async ValueTask<Result<ICollection<UserResponse>>> GetAllUsersByBusinessIdAsync(Ulid idBusiness)
    {
        try
        {
            return await _context.Users
                .Where(x => x.IdBusiness == idBusiness)
                .Select(x => new UserResponse
                {
                    UserId = x.Id,
                    Name = x.Name,
                    Family = x.Family,
                    IdBusiness = x.IdBusiness,
                    Gender = x.Gender,
                    BusinessName = x.IdBusinessNavigation.BusinessName,
                    CodeMelli = x.CodeMelli,
                    Address = x.Address,
                    CreatedOn = x.CreatedOn,
                    DateOfBirth = x.DateOfBirth,
                    Flag = x.Flag,
                    Married = x.Married,
                    LastIp = x.LastIp,
                    LastLogin = x.LastLogin
                })
                .ToListAsync();
        }
        catch (Exception e)
        {
            return new Result<ICollection<UserResponse>>(new ValidationException(e.Message));
        }
    }
}