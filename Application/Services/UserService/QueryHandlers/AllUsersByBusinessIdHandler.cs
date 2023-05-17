namespace Application.Services.UserService.QueryHandlers;

public readonly struct AllUsersByBusinessIdHandler : IRequestHandler<AllUsersByBusinessIdQuery, Result<ICollection<UserResponse>>>
{
    private readonly IUserRepository _repository;

    public AllUsersByBusinessIdHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<UserResponse>>> Handle(AllUsersByBusinessIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllUsersByBusinessIdAsync(request.BusinessId))
                .Match(result => new Result<ICollection<UserResponse>>(result),
                    exception => new Result<ICollection<UserResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<UserResponse>>(new Exception(e.Message));
        }
    }
}