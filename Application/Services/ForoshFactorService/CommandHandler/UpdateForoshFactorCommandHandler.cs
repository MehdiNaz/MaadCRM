namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct UpdateForoshFactorCommandHandler : IRequestHandler<UpdateForoshFactorCommand, Result<ForooshFactor>>
{
    private readonly IForoshFactorRepository _repository;

    public UpdateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshFactor>> Handle(UpdateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateForoshFactorCommand item = new()
            {
                Id = request.Id,
                CustomerId = request.CustomerId,
                CustomersAddressId = request.CustomersAddressId
            };

            return (await _repository.UpdateForoshFactorAsync(item))
                .Match(result => new Result<ForooshFactor>(result),
                    exception => new Result<ForooshFactor>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshFactor>(new Exception(e.Message));
        }
    }
}