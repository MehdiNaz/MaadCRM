using Domain.Models.Businesses;

namespace WebApi.Test;
public interface ITest1Service
{
    public Task<bool> t1();

}

public class Test1Service : ITest1Service
{
    private readonly MaadContext _context;
    private readonly UserManager<User> _userManager;
    public Test1Service(MaadContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<bool> t1()
    {
        var phone = "09397142757";
        var newBusiness = new Business()
        {
            BusinessName = " شرکت" + phone
        };
        await _context.Businesses!.AddAsync(newBusiness);
        var result = await _context.SaveChangesAsync();
        
        var user = new User()
        {
            LoginCount = 1,
            PhoneNumber = phone,
            UserName = phone,
            UserStatus = Status.Show,
            BusinessId = newBusiness.Id,
            CreatedOn = DateTime.UtcNow
        };
        
        var createUserResult = await _userManager.CreateAsync(user);
        
        return createUserResult.Succeeded;
    }

}