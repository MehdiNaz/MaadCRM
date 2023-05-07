namespace Application.Services.Customer.Foroosh.ForooshFactorService.CommandHandler;

public readonly struct DeleteForooshFactorCommandHandler : IRequestHandler<DeleteForooshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForooshFactorRepository _repository;

    public DeleteForooshFactorCommandHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(DeleteForooshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteForooshFactorAsync(request.Id))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}