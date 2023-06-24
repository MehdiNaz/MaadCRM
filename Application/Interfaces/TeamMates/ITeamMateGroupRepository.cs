using Application.Services.TeamMates.Query;

namespace Application.Interfaces.TeamMates;

public interface ITeamMateGroupRepository
{
    ValueTask<Result<TeamMateGroupResponse>> AddTeamMateGroupAsync(AddTeamMateGroupCommand request);
    ValueTask<Result<TeamMateGroupResponse>> EditTeamMateGroupAsync(EditTeamMateGroupCommand request);
    ValueTask<Result<TeamMateGroupResponse>> GetTeamMateGroupById(GetTeamMateGroupByIdQuery request);
    ValueTask<Result<ICollection<TeamMateGroupResponse>>> AllTeamMateGroupsAsync(AllUserGroupsQuery request);
    ValueTask<Result<TeamMateGroupResponse>> DeleteTeamMateGroupAsync(DeleteTeamMateGroupCommand request);

}