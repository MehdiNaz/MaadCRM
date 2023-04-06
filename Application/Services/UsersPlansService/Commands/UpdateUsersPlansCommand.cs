namespace Application.Services.UsersPlansService.Commands;

public abstract class UpdateUsersPlansCommand : RequestCreateUsersPlans, IRequest<UsersPlans>
{
    public Ulid UsersPlansId { get; set; }
}