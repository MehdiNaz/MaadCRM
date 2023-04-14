namespace Application.Services.Profile.CommandHandler;

public readonly struct SetProfileHandler : IRequestHandler<SetProfileCommand, Result<User>>
{
    private readonly IProfileRepository _repository;
    
    public SetProfileHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<User>> Handle(SetProfileCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _repository.SetProfile(request);
            return result.Match(resultCode => new Result<User>(resultCode), exception => new Result<User>(exception));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}