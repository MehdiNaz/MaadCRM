namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct CreateForoshFactorCommandHandler : IRequestHandler<CreateForoshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForoshFactorRepository _repository;

    public CreateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(CreateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateForoshFactorCommand item = new()
            {
                CustomerId = request.CustomerId,
                CustomersAddressId = request.CustomersAddressId
            };
            return (await _repository.CreateForoshFactorAsync(item))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}
