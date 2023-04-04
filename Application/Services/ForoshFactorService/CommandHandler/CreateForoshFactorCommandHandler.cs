namespace Application.Services.ForoshFactorService.CommandHandler;

public class CreateForoshFactorCommandHandler : IRequestHandler<CreateForoshFactorCommand, ForoshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public CreateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshFactor> Handle(CreateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        ForoshFactor item = new()
        {
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            FinalTotal = request.FinalTotal
        };
        await _repository.CreateForoshFactorAsync(item);
        return item;
    }
}
