namespace Application.Interfaces.Plans;

public interface IUsersPlansRepository
{
    ValueTask<ICollection<UsersPlans?>> GetAllActivePlansAsync();
    ValueTask<UsersPlans?> GetTheLatestPlanAsync();
    ValueTask<ICollection<ResponseUsersPlans?>> GetUsersPlansByIdAsync(string usersId);
    ValueTask<bool> ChangeStatusAsync(Status status, string usersId);
    ValueTask<UsersPlans?> CreateUsersPlansAsync(UsersPlans entity);
    ValueTask<UsersPlans?> UpdateUsersPlansAsync(UsersPlans entity, Ulid usersPlansId);
    ValueTask<UsersPlans?> DeleteUsersPlansAsync(Ulid usersPlansId);
}
