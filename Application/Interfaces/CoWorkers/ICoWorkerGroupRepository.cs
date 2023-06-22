namespace Application.Interfaces.CoWorkers;

public interface ICoWorkerGroupRepository
{
    ValueTask<Result<TeamMateGroupResponse>> AddCoworkerGroupAsync(AddCoworkerGroupCommand request);
    ValueTask<Result<TeamMateGroupResponse>> EditCoworkerGroupAsync(EditCoworkerGroupCommand request);
    ValueTask<Result<TeamMateGroupResponse>> GetUserGroupById(GetUserGroupByIdQuery request);
    ValueTask<Result<ICollection<TeamMateGroupResponse>>> AllCoworkerGroupAsync(AllUserGroupsQuery request);
    ValueTask<Result<TeamMateGroupResponse>> DeleteCoworkerGroupAsync(DeleteCoworkerGroupCommand request);

}