using Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.CommandHandler;

public readonly struct CreateForooshOrderCommandHandler : IRequestHandler<CreateForooshOrderCommand, ForooshOrder>
{
    private readonly IForooshOrderRepository _repository;

    public CreateForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(CreateForooshOrderCommand request, CancellationToken cancellationToken)
    {
        CreateForooshOrderCommand item = new()
        {
            Price = request.Price,
            ShippingPrice = request.ShippingPrice,
            PriceTotal = request.PriceTotal,
            DiscountPrice = request.DiscountPrice,
            ShippingMethodType = request.ShippingMethodType,
            ProductId = request.ProductId
        };
        return await _repository.CreateForooshOrderAsync(item);
    }
}
