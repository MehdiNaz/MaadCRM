namespace Application.Interfaces.IdentityUsers;

public interface IUserRepository
{
    ValueTask<Result<ICollection<User>>> GetAllUsersByBusinessIdAsync(Ulid businessId);
}