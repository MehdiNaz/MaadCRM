namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct ChangeStatusForoshOrderCommandHandler : IRequestHandler<ChangeStatusForoshOrderCommand, ForoshOrder?>
{
    private readonly IForoshOrderRepository _repository;

    public ChangeStatusForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshOrder?> Handle(ChangeStatusForoshOrderCommand request, CancellationToken cancellationToken)
        => await _repository.ChangeStatusForoshOrderByIdAsync(request);
}