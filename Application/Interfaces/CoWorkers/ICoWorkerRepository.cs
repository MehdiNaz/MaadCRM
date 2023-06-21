namespace Application.Interfaces.CoWorkers;

public interface ICoWorkerRepository
{
    ValueTask<Result<bool>> AddCoworkerAsync(AddCoworkerCommand request);
}