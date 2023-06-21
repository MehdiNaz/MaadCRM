namespace Application.Interfaces.CoWorkers;

public interface ICoWorkerGroupRepository
{
    ValueTask<Result<TeamMateGroupRespnse>> AddCoworkerGroupAsync(AddCoworkerGroupCommand request);
}