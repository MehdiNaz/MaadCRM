namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct UpdateForoshOrderCommandHandler : IRequestHandler<UpdateForoshOrderCommand, ForooshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public UpdateForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(UpdateForoshOrderCommand request, CancellationToken cancellationToken)
    {
        UpdateForoshOrderCommand item = new()
        {
            Id = request.Id,
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
        return await _repository.UpdateForoshOrderAsync(item);
    }
}