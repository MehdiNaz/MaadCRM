namespace Application.Services.Customer.Foroosh.ForooshFactorService.CommandHandler;

public readonly struct ChangeStatusForooshFactorCommandHandler : IRequestHandler<ChangeStatusForooshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForooshFactorRepository _repository;

    public ChangeStatusForooshFactorCommandHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(ChangeStatusForooshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusForooshFactorByIdAsync(request))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}