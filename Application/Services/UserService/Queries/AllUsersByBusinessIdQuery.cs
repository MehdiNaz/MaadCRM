namespace Application.Services.UserService.Queries;

public struct AllUsersByBusinessIdQuery : IRequest<Result<ICollection<UserResponse>>>
{
    public Ulid BusinessId { get; set; }
}