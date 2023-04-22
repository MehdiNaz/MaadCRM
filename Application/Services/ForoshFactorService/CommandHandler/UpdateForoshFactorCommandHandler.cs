using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.CommandHandler;

public readonly struct UpdateForoshFactorCommandHandler : IRequestHandler<UpdateForoshFactorCommand, ForooshFactor>
{
    private readonly IForoshFactorRepository _repository;

    public UpdateForoshFactorCommandHandler(IForoshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshFactor> Handle(UpdateForoshFactorCommand request, CancellationToken cancellationToken)
    {
        UpdateForoshFactorCommand item = new()
        {
            Id = request.Id,
            Price = request.Price,
            DiscountPrice = request.DiscountPrice,
            FinalTotal = request.FinalTotal,
            CustomerId = request.CustomerId,
            CustomersAddressId = request.CustomersAddressId
        };
        return await _repository.UpdateForoshFactorAsync(item);
    }
}