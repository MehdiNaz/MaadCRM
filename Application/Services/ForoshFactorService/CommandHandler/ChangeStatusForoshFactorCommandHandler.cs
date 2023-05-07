namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct ChangeStatusForoshFactorCommandHandler : IRequestHandler<ChangeStatusForoshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForoshFactorRepository _repository;

    public ChangeStatusForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(ChangeStatusForoshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusForoshFactorByIdAsync(request))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}