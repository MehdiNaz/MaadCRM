namespace Application.Services.UsersPlansService.Commands;

public abstract class DeleteUsersPlansCommand : IRequest<UsersPlans>
{
    public Ulid UsersPlansId { get; set; }
}