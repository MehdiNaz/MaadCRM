using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct ChangeStatusForoshOrderCommandHandler : IRequestHandler<ChangeStatusForoshOrderCommand, ForooshOrder?>
{
    private readonly IForoshOrderRepository _repository;

    public ChangeStatusForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder?> Handle(ChangeStatusForoshOrderCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusForoshOrderByIdAsync(request);
}