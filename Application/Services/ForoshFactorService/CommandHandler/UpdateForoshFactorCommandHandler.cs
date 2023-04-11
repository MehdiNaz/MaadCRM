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
        ForoshFactor item = new()
        {
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            FinalTotal = request.FinalTotal
        };
        await _repository.UpdateForoshFactorAsync(item, request.ForoshFactorId);
        return item;
    }
}