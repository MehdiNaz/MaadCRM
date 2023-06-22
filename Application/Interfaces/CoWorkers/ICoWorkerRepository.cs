namespace Application.Interfaces.CoWorkers;

public interface ICoWorkerRepository
{
    ValueTask<Result<bool>> AddCoworkerAsync(AddCoworkerCommand request);
    ValueTask<Result<TeamMateResponse>> EditCoworkerAsync(EditCoworkerCommand request);
    ValueTask<Result<TeamMateResponse>> DeleteCoworkerAsync(DeleteCoworkerCommand request);
    ValueTask<Result<ICollection<TeamMateResponse>>> GetAllCoworkerAsync(AllUsersQuery request);
    ValueTask<Result<TeamMateResponse>> GetCoworkerByIdAsync(GetUserByIdQuery request);


}