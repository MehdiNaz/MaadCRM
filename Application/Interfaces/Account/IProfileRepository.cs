namespace Application.Interfaces.Account;

public interface IProfileRepository
{
    ValueTask<User?> SetProfile(SetProfileCommand request);
}