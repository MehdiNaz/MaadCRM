﻿namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct CreateForoshOrderCommandHandler : IRequestHandler<CreateForoshOrderCommand, ForooshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public CreateForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(CreateForoshOrderCommand request, CancellationToken cancellationToken)
    {
        CreateForoshOrderCommand item = new()
        {
            Price = request.Price,
            ShippingPrice = request.ShippingPrice,
            PriceTotal = request.PriceTotal,
            DiscountPrice = request.DiscountPrice,
            ShippingMethodType = request.ShippingMethodType,
            ProductId = request.ProductId
        };
        return await _repository.CreateForoshOrderAsync(item);
    }
}
