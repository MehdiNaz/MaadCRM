namespace Application.Services.UserService.QueryHandlers;

public readonly struct AllUsersByBusinessIdHandler : IRequestHandler<AllUsersByBusinessIdQuery, Result<ICollection<User>>>
{
    private readonly IUserRepository _repository;

    public AllUsersByBusinessIdHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<User>>> Handle(AllUsersByBusinessIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllUsersByBusinessIdAsync(request.BusinessId))
                .Match(result => new Result<ICollection<User>>(result),
                    exception => new Result<ICollection<User>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<User>>(new Exception(e.Message));
        }
    }
}