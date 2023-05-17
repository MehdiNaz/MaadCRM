namespace Application.Interfaces.IdentityUsers;

public interface IUserRepository
{
    ValueTask<Result<ICollection<UserResponse>>> GetAllUsersByBusinessIdAsync(Ulid businessId);
}