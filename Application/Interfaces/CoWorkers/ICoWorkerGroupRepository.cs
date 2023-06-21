namespace Application.Interfaces.CoWorkers;

public interface ICoWorkerGroupRepository
{
    ValueTask<Result<TeamMateGroupRespnse>> AddCoworkerGroupAsync(AddCoworkerGroupCommand request);
    ValueTask<Result<TeamMateGroupRespnse>> EditCoworkerGroupAsync(EditCoworkerGroupCommand request);
    ValueTask<Result<TeamMateGroupRespnse>> GetUserGroupById(GetUserGroupByIdQuery request);
    ValueTask<Result<ICollection<TeamMateGroupRespnse>>> AllCoworkerGroupAsync(AllUserGroupsQuery request);
    ValueTask<Result<TeamMateGroupRespnse>> DeleteCoworkerGroupAsync(DeleteCoworkerGroupCommand request);

}