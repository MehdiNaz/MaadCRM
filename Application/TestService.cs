namespace Application.Services;
public interface ITestService
{
    Task<bool> AddRole();
}

public class TestService : ITestService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    // private readonly ApplicationDbContext _context;

    public TestService(
        RoleManager<IdentityRole> roleManager
        // ApplicationDbContext context
    )
    {
        _roleManager = roleManager;
        // _context = context;
    }


    public async Task<bool> AddRole()
    {
        await _roleManager.CreateAsync(new IdentityRole(UserRole.User));
        await _roleManager.CreateAsync(new IdentityRole(UserRole.Company));
        await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));
        return true;
    }
}
