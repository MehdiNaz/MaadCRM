namespace Application.Services.Customer.Foroosh.ForoshOrderService.CommandHandler;

public readonly struct UpdateForooshOrderCommandHandler : IRequestHandler<UpdateForooshOrderCommand, Result<ForooshOrder>>
{
    private readonly IForooshOrderRepository _repository;

    public UpdateForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshOrder>> Handle(UpdateForooshOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateForooshOrderCommand item = new()
            {
                Id = request.Id,
                Price = request.Price,
                ShippingPrice = request.ShippingPrice,
                PriceTotal = request.PriceTotal,
                DiscountPrice = request.DiscountPrice,
            };
            return (await _repository.UpdateForooshOrderAsync(item))
                .Match(result => new Result<ForooshOrder>(result),
                    exception => new Result<ForooshOrder>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new Exception(e.Message));
        }
    }
}