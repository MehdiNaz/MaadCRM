namespace Application.Services.Profile.CommandHandler;

public readonly struct SetProfileHandler : IRequestHandler<SetProfileCommand, User?>
{
    private readonly IProfileRepository _repository;
    
    public SetProfileHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<User?> Handle(SetProfileCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.SetProfile(request);
        return result;
    }
}