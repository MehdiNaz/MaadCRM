
using Application.Responses.TeamMate;

namespace DataAccess.Repositories.CoWorkers;

public class CoWorkerGroupRepository:ICoWorkerGroupRepository
{
    private readonly UserManager<User> _userManager;
    private readonly MaadContext _context;
    
    public CoWorkerGroupRepository(
        UserManager<User> userManager, 
        MaadContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async ValueTask<Result<TeamMateGroupRespnse>> AddCoworkerGroupAsync(AddCoworkerGroupCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateGroupRespnse>(new ValidationException(ResultErrorMessage.NotFound));
        
            UserGroup userGroup = new()
            {
                Title = request.Title,
                IdUserAdded = request.IdUser,
                IdUserUpdated = request.IdUser,
                IdBusiness = findUser.IdBusiness,
            };

            await _context.UserGroups.AddAsync(userGroup);
            await _context.SaveChangesAsync();

            TeamMateGroupRespnse result = new()
            {
                Id = userGroup.Id,
                Title = userGroup.Title,
                IdBusiness = userGroup.IdBusiness,
                Status = userGroup.Status,
                DisplayOrder = userGroup.DisplayOrder
            };
            return new Result<TeamMateGroupRespnse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupRespnse>(e);
        }
    }
}