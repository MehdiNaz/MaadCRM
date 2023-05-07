using Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.CommandHandler;

public readonly struct UpdateForooshOrderCommandHandler : IRequestHandler<UpdateForooshOrderCommand, ForooshOrder>
{
    private readonly IForooshOrderRepository _repository;

    public UpdateForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(UpdateForooshOrderCommand request, CancellationToken cancellationToken)
    {
        UpdateForooshOrderCommand item = new()
        {
            Id = request.Id,
            Price = request.Price,
            ShippingPrice = request.ShippingPrice,
            PriceTotal = request.PriceTotal,
            DiscountPrice = request.DiscountPrice,
        };
        return await _repository.UpdateForooshOrderAsync(item);
    }
}