namespace Application.Services.Customer.Foroosh.ForoshOrderService.CommandHandler;

public readonly struct CreateForooshOrderCommandHandler : IRequestHandler<CreateForooshOrderCommand, Result<ForooshOrder>>
{
    private readonly IForooshOrderRepository _repository;

    public CreateForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshOrder>> Handle(CreateForooshOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateForooshOrderCommand item = new()
            {
                Price = request.Price,
                ShippingPrice = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                DiscountPrice = request.DiscountPrice,
                ProductId = request.ProductId,
                FactorId = request.FactorId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
            return (await _repository.CreateForooshOrderAsync(item))
                    .Match(result => new Result<ForooshOrder>(result),
                        exception => new Result<ForooshOrder>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new Exception(e.Message));
        }
    }
}
