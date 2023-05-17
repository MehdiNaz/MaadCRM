namespace Application.Services.UserService.Queries;

public struct AllUsersByBusinessIdQuery : IRequest<Result<ICollection<User>>>
{
    public Ulid BusinessId { get; set; }
}