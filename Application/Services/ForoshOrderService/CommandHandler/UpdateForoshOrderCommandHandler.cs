namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct UpdateForoshOrderCommandHandler : IRequestHandler<UpdateForoshOrderCommand, ForoshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public UpdateForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshOrder> Handle(UpdateForoshOrderCommand request, CancellationToken cancellationToken)
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
        await _repository.UpdateForoshOrderAsync(item, request.ForoshOrderId);
        return item;
    }
}