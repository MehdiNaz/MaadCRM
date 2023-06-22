
using Application.Responses.TeamMate;
using Application.Services.CoWorkers.Query;

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

    public async ValueTask<Result<TeamMateGroupResponse>> AddCoworkerGroupAsync(AddCoworkerGroupCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            UserGroup userGroup = new()
            {
                Title = request.Title,
                IdUserAdded = request.IdUser,
                IdUserUpdated = request.IdUser,
                IdBusiness = findUser.IdBusiness,
            };

            await _context.UserGroups.AddAsync(userGroup);
            await _context.SaveChangesAsync();

            TeamMateGroupResponse result = new()
            {
                Id = userGroup.Id,
                Title = userGroup.Title,
                IdBusiness = userGroup.IdBusiness,
                Status = userGroup.Status,
                DisplayOrder = userGroup.DisplayOrder
            };
            return new Result<TeamMateGroupResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(e);
        }
    }

    public async ValueTask<Result<TeamMateGroupResponse>> EditCoworkerGroupAsync(EditCoworkerGroupCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            var findUserGroup = await _context.UserGroups.FindAsync(request.Id);
            if (findUserGroup is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
            
            findUserGroup.Title = request.Title;
            findUserGroup.IdUserUpdated = request.IdUser;
            // findUserGroup.Status = request.Status.Value;
            // findUserGroup.DisplayOrder = request.DisplayOrder.Value;
            _context.UserGroups.Update(findUserGroup);
            await _context.SaveChangesAsync();

            TeamMateGroupResponse result = new()
            {
                Id = findUserGroup.Id,
                Title = findUserGroup.Title,
                IdBusiness = findUserGroup.IdBusiness,
                Status = findUserGroup.Status,
                DisplayOrder = findUserGroup.DisplayOrder
            };
            return new Result<TeamMateGroupResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(e);
        }
    }

    public async ValueTask<Result<TeamMateGroupResponse>> GetUserGroupById(GetUserGroupByIdQuery request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            var findUserGroup = await _context
                .UserGroups
                .Select(s => new TeamMateGroupResponse
                {
                    Id = s.Id,
                    Title = s.Title,
                    IdBusiness = s.IdBusiness,
                    Status = s.Status,
                    DisplayOrder = s.DisplayOrder
                })
                .FirstOrDefaultAsync(g => g.Id == request.Id && g.IdBusiness == findUser.IdBusiness);
            
            return new Result<TeamMateGroupResponse>(findUserGroup);
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(e);
        }
    }

    public async ValueTask<Result<ICollection<TeamMateGroupResponse>>> AllCoworkerGroupAsync(AllUserGroupsQuery request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<ICollection<TeamMateGroupResponse>>(new ValidationException(ResultErrorMessage.NotFound));
        
            var findUserGroup = await _context
                .UserGroups
                .Select(s => new TeamMateGroupResponse
                {
                    Id = s.Id,
                    Title = s.Title,
                    IdBusiness = s.IdBusiness,
                    Status = s.Status,
                    DisplayOrder = s.DisplayOrder
                })
                .Where(g => g.Id == request.Id && g.IdBusiness == findUser.IdBusiness)
                .ToListAsync();
            
            return new Result<ICollection<TeamMateGroupResponse>>(findUserGroup);
        }
        catch (Exception e)
        {
            return new Result<ICollection<TeamMateGroupResponse>>(e);
        }
    }

    public async ValueTask<Result<TeamMateGroupResponse>> DeleteCoworkerGroupAsync(DeleteCoworkerGroupCommand request)
    {
        try
        {
            var findUser = await _context.Users.FindAsync(request.IdUser);
            if (findUser is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
        
            var findUserGroup = await _context.UserGroups.FindAsync(request.Id);
            if (findUserGroup is null) return new Result<TeamMateGroupResponse>(new ValidationException(ResultErrorMessage.NotFound));
            
            findUserGroup.Status = StatusType.Deleted;
            
            _context.UserGroups.Update(findUserGroup);
            await _context.SaveChangesAsync();

            TeamMateGroupResponse result = new()
            {
                Id = findUserGroup.Id,
                Title = findUserGroup.Title,
                IdBusiness = findUserGroup.IdBusiness,
                Status = findUserGroup.Status,
                DisplayOrder = findUserGroup.DisplayOrder
            };
            return new Result<TeamMateGroupResponse>(result);
        }
        catch (Exception e)
        {
            return new Result<TeamMateGroupResponse>(e);
        }
    }
}