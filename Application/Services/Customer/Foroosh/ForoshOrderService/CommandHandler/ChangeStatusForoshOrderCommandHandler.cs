using Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.CommandHandler;

public readonly struct ChangeStatusForooshOrderCommandHandler : IRequestHandler<ChangeStatusForooshOrderCommand, ForooshOrder?>
{
    private readonly IForooshOrderRepository _repository;

    public ChangeStatusForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder?> Handle(ChangeStatusForooshOrderCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusForooshOrderByIdAsync(request);
}