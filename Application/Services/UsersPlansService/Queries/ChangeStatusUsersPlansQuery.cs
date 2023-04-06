namespace Application.Services.UsersPlansService.Queries;

public abstract class ChangeStatusUsersPlansQuery : IRequest<bool>
{
    public required Status Status { get; set; }
    public required string UserId { get; set; }
}
