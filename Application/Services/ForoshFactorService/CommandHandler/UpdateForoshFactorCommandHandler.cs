namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct UpdateForoshFactorCommandHandler : IRequestHandler<UpdateForoshFactorCommand, ForoshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public UpdateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor> Handle(UpdateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        UpdateForoshFactorCommand item = new()
        {
            Id = request.Id,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            FinalTotal = request.FinalTotal,
            CustomerId = request.CustomerId,
            CustomersAddressId = request.CustomersAddressId
        };
        return await _repository.UpdateForoshFactorAsync(item);
    }
}