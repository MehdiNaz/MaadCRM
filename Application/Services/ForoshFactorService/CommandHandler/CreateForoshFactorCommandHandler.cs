namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct CreateForoshFactorCommandHandler : IRequestHandler<CreateForoshFactorCommand, ForoshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public CreateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor> Handle(CreateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        CreateForoshFactorCommand item = new()
        {
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            FinalTotal = request.FinalTotal,
            CustomerId = request.CustomerId,
            CustomersAddressId = request.CustomersAddressId
        };
        return await _repository.CreateForoshFactorAsync(item);
    }
}
