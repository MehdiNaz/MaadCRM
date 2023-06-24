using Application.Interfaces.TeamMates;
using Application.Services.TeamMates.Command;
using Application.Services.TeamMates.Query;

namespace DataAccess.Repositories.TeamMates;

public class TeamMateRepository:ITeamMateRepository
{
    private readonly UserManager<User> _userManager;
    private readonly MaadContext _context;
    // private readonly RoleManager<IdentityRole> _roleManager;
    
    public TeamMateRepository(
        UserManager<User> userManager, 
        MaadContext context 
        // RoleManager<IdentityRole> roleManager
        )
    {
        _userManager = userManager;
        _context = context;
        // _roleManager = roleManager;
    }
    
    public async ValueTask<Result<bool>> AddTeamMateAsync(AddTeamMateCommand request)
    {
        try
        {
            // await _roleManager.CreateAsync(new IdentityRole(UserRoleTypes.User));
            // await _roleManager.CreateAsync(new IdentityRole(UserRoleTypes.Admin));
            // await _roleManager.CreateAsync(new IdentityRole(UserRoleTypes.Company));

            
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<bool>(new ValidationException(ResultErrorMessage.NotFound));

            var user = new User
            {
                LoginCount = 1,
                PhoneNumber = request.PhoneNo,
                UserName = request.PhoneNo,
                Status = StatusType.Show,
                Name = request.Name,
                Family = request.Family,
                DateOfBirth = request.BirthDate,
                Email = request.Email,
                Address = request.Address,
                Gender = request.Gender,
                CodeMelli = request.CodeMelli,
                IdBusiness = findUser.IdBusiness,
                PhoneNumberConfirmed = true,
                CreatedOn = DateTime.UtcNow,
                IdGroup = request.IdGroup
            };

            if (request.IdCity != Ulid.Empty)
                user.IdCity = request.IdCity;

            var createUserResult = await _userManager.CreateAsync(user);
            if (!createUserResult.Succeeded)
                return new Result<bool>(new ValidationException("خطا در ثبت اطلاعات کاربر"));

            await _userManager.AddToRoleAsync(user, UserRoleTypes.User);

            return new Result<bool>(createUserResult.Succeeded);
        }
        catch (Exception e)
        {
            return new Result<bool>(new ValidationException(e.Message));
        }

    }

    public async ValueTask<Result<TeamMateResponse>> EditTeamMateAsync(EditTeamMateCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateResponse>(new ValidationException(ResultErrorMessage.NotFound));

            var resultEditUser = await _context.Users.FirstOrDefaultAsync(w => w.Id == request.Id && w.IdBusiness == findUser.IdBusiness);
            if (resultEditUser is null) return new Result<TeamMateResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            resultEditUser.Name = request.Name;
            resultEditUser.Family = request.Family;
            resultEditUser.DateOfBirth = request.BirthDate;
            resultEditUser.Email = request.Email;
            resultEditUser.Address = request.Address;
            resultEditUser.Gender = request.Gender;
            resultEditUser.CodeMelli = request.CodeMelli;
            resultEditUser.IdGroup = request.IdGroup;
            resultEditUser.PhoneNumber = request.PhoneNo;
            resultEditUser.PhoneNumberConfirmed = true;
            
            if (request.IdCity != Ulid.Empty)
                resultEditUser.IdCity = request.IdCity;
        
            await _context.SaveChangesAsync();

            var result = await _context
                .Users
                // .Include(g => g.IdGroupNavigation)
                // .Include(c => c.IdCityNavigation)
                // .ThenInclude(p => p!.IdProvinceNavigation)
                .Select(u => new TeamMateResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Family = u.Family,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    Address = u.Address,
                    Gender = u.Gender,
                    CodeMelli = u.CodeMelli,
                    IdCity = u.IdCity,
                    IdGroup = u.IdGroup,
                    PhoneNo = u.PhoneNumber,
                    PostalCode = u.PostalCode,
                    Married = u.Married,
                    CreatedOn = u.CreatedOn,
                    GroupTitle = u.IdGroupNavigation.Title,
                    CityName = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.CityName
                        : "",
                    IdProvince = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.IdProvince
                        : Ulid.Empty,
                    ProvinceName =  u.IdCityNavigation != null
                        ?  u.IdCityNavigation!.IdProvinceNavigation!.ProvinceName
                        : ""
                })
                .FirstOrDefaultAsync(w => w.Id == request.Id);
        
            return new Result<TeamMateResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<TeamMateResponse>> DeleteTeamMateAsync(DeleteTeamMateCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateResponse>(new ValidationException(ResultErrorMessage.NotFound));

            var resultEditUser = await _context.Users.FirstOrDefaultAsync(w => w.Id == request.Id && w.IdBusiness == findUser.IdBusiness);
            if (resultEditUser is null) return new Result<TeamMateResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            resultEditUser.Status = StatusType.Deleted;
            await _context.SaveChangesAsync();

            var result = await _context
                .Users
                .Include(g => g.IdGroupNavigation)
                .Include(c => c.IdCityNavigation)
                .ThenInclude(p => p!.IdProvinceNavigation)
                .Select(u => new TeamMateResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Family = u.Family,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    Address = u.Address,
                    Gender = u.Gender,
                    CodeMelli = u.CodeMelli,
                    IdCity = u.IdCity,
                    IdGroup = u.IdGroup,
                    PhoneNo = u.PhoneNumber,
                    PostalCode = u.PostalCode,
                    Married = u.Married,
                    CreatedOn = u.CreatedOn,
                    GroupTitle = u.IdGroupNavigation.Title,
                    CityName = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.CityName
                        : "",
                    IdProvince = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.IdProvince
                        : Ulid.Empty,
                    ProvinceName =  u.IdCityNavigation != null
                        ?  u.IdCityNavigation!.IdProvinceNavigation!.ProvinceName
                        : ""
                })
                .FirstOrDefaultAsync(w => w.Id == request.Id);
        
            return new Result<TeamMateResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<ICollection<TeamMateResponse>>> GetAllTeamMatesAsync(AllUsersQuery request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<ICollection<TeamMateResponse>>(new ValidationException(ResultErrorMessage.NotFound));

            var result = await _context
                .Users
                .Include(g => g.IdGroupNavigation)
                .Include(c => c.IdCityNavigation)
                .ThenInclude(p => p!.IdProvinceNavigation)
                .Where(w => w.IdBusiness == findUser.IdBusiness)
                .Select(u => new TeamMateResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Family = u.Family,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    Address = u.Address,
                    Gender = u.Gender,
                    CodeMelli = u.CodeMelli,
                    IdCity = u.IdCity,
                    IdGroup = u.IdGroup,
                    PhoneNo = u.PhoneNumber,
                    PostalCode = u.PostalCode,
                    Married = u.Married,
                    CreatedOn = u.CreatedOn,
                    GroupTitle = u.IdGroupNavigation.Title,
                    CityName = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.CityName
                        : "",
                    IdProvince = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.IdProvince
                        : Ulid.Empty,
                    ProvinceName =  u.IdCityNavigation != null
                        ?  u.IdCityNavigation!.IdProvinceNavigation!.ProvinceName
                        : ""
                })
                .ToListAsync();
                
            return new Result<ICollection<TeamMateResponse>>(result);
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateResponse>>(new ValidationException(e.Message));
        }
    }

    public async ValueTask<Result<TeamMateResponse>> GetTeamMateByIdAsync(GetTeamMateByIdQuery request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateResponse>(new ValidationException(ResultErrorMessage.NotFound));

            var result = await _context
                .Users
                .Include(g => g.IdGroupNavigation)
                .Include(c => c.IdCityNavigation)
                .ThenInclude(p => p!.IdProvinceNavigation)
                .Where(w => w.Id == request.Id && w.IdBusiness == findUser.IdBusiness)
                .Select(u => new TeamMateResponse
                {
                    Id = u.Id,
                    Name = u.Name,
                    Family = u.Family,
                    DateOfBirth = u.DateOfBirth,
                    Email = u.Email,
                    Address = u.Address,
                    Gender = u.Gender,
                    CodeMelli = u.CodeMelli,
                    IdCity = u.IdCity,
                    IdGroup = u.IdGroup,
                    PhoneNo = u.PhoneNumber,
                    PostalCode = u.PostalCode,
                    Married = u.Married,
                    CreatedOn = u.CreatedOn,
                    GroupTitle = u.IdGroupNavigation.Title,
                    CityName = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.CityName
                        : "",
                    IdProvince = u.IdCityNavigation != null
                        ?  u.IdCityNavigation.IdProvince
                        : Ulid.Empty,
                    ProvinceName =  u.IdCityNavigation != null
                        ?  u.IdCityNavigation!.IdProvinceNavigation!.ProvinceName
                        : ""
                })
                .FirstOrDefaultAsync();
                
            return new Result<TeamMateResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateResponse>(new ValidationException(e.Message));
        }
    }
}