using Application.Interfaces.Account;
using Application.Services.Profile.Command;

namespace DataAccess.Repositories.Account;

public class ProfileRepository:IProfileRepository
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly MaadContext _context;

    public ProfileRepository(UserManager<User> userManager, SignInManager<User> signInManager,MaadContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }
    public async ValueTask<User?> SetProfile(SetProfileCommand request)
    {
        var result = await _userManager.FindByIdAsync(request.Id);
        if (result == null)
            return null;
        
        result.Id = request.Id;
        result.Email = request.Email;
        result.Gender = request.Gender;
        result.Name = request.Name;
        result.Family = request.Family;
        result.Address = request.Address;
        result.DateOfBirth = request.BirthDatre;
        result.CodeMelli = request.CodeMelli;
        // result.CityId = request.CityId;
        
        await _userManager.UpdateAsync(result);

        return result;
    }
}