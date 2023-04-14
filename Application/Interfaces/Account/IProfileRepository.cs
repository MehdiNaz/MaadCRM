namespace Application.Interfaces.Account;

public interface IProfileRepository
{
    ValueTask<Result<User>> SetProfile(SetProfileCommand request);
}