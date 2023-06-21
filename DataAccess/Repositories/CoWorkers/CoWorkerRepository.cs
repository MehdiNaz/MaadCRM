
namespace DataAccess.Repositories.CoWorkers;

public class CoWorkerRepository:ICoWorkerRepository
{
    private readonly UserManager<User> _userManager;
    private readonly MaadContext _context;
    
    public CoWorkerRepository(
        UserManager<User> userManager, 
        MaadContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    public async ValueTask<Result<bool>> AddCoworkerAsync(AddCoworkerCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<bool>(new ValidationException(ResultErrorMessage.NotFound));

            var user = new User
            {
                LoginCount = 1,
                PhoneNumber = request.PhoneNo,
                UserName = request.PhoneNo,
                UserStatusType = StatusType.Show,
                Name = request.Name,
                Family = request.Family,
                DateOfBirth = request.BirthDate,
                Email = request.Email,
                Address = request.Address,
                Gender = request.Gender,
                CodeMelli = request.CodeMelli,
                CityId = request.IdCity,
                IdBusiness = findUser.IdBusiness,
                PhoneNumberConfirmed = true,
                CreatedOn = DateTime.UtcNow,
                IdGroup = request.IdGroup
            };

            var createUserResult = await _userManager.CreateAsync(user);
            if (!createUserResult.Succeeded)
                return new Result<bool>(new ValidationException("خطا در ثبت اطلاعات کاربر"));

            // TODO: Add to role
            // await _userManager.AddToRoleAsync(user, UserRoleTypes.User);

            return new Result<bool>(createUserResult.Succeeded);
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }

    }
}