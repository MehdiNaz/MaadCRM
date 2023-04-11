namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct CreateForoshOrderCommandHandler : IRequestHandler<CreateForoshOrderCommand, ForoshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public CreateForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshOrder> Handle(CreateForoshOrderCommand request, CancellationToken cancellationToken)
    {
        ForoshOrder item = new()
        {
            PaymentDate = request.PaymentDate,
            Price = request.Price,
            ShippingPrice = request.ShippingPrice,
            PriceTotal = request.PriceTotal,
            DiscountPrice = request.DiscountPrice,
            Description = request.Description,
            PaymentMethodType = request.PaymentMethodType,
            ShippingMethodType = request.ShippingMethodType,
            ProductId = request.ProductId
        };
        await _repository.CreateForoshOrderAsync(item);
        return item;
    }
}
