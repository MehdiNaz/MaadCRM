namespace Application.Services.UsersPlansService.Queries;

public abstract class GetUsersPlansByIdQuery : IRequest<ICollection<ResponseUsersPlans?>>
{
    public required string UserId { get; set; }
}