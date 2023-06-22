using Application.Services.Profile.Command;

namespace DataAccess.Repositories.Account;

public class ProfileRepository : IProfileRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly MaadContext _context;

    public ProfileRepository(UserManager<User> userManager, SignInManager<User> signInManager, MaadContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async ValueTask<Result<User>> SetProfile(SetProfileCommand request)
    {
        try
        {
            var result = await _userManager.FindByIdAsync(request.Id);
            if (result == null)
                return new Result<User>(new Exception("User not found"));

            result.Id = request.Id;
            result.Email = request.Email;
            result.Gender = request.Gender;
            result.Name = request.Name;
            result.Family = request.Family;
            result.Address = request.Address;
            result.DateOfBirth = request.BirthDate;
            result.CodeMelli = request.CodeMelli;
            result.IdCity = request.CityId;

            await _userManager.UpdateAsync(result);

            return new Result<User>(result);
        }
        catch (Exception e)
        {
            return new Result<User>(new Exception("User update failed"));
        }
    }
}