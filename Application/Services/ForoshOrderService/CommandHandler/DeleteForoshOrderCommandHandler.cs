namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct DeleteForoshOrderCommandHandler : IRequestHandler<DeleteForoshOrderCommand, ForoshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public DeleteForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForoshOrder> Handle(DeleteForoshOrderCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteForoshOrderAsync(request.ForoshOrderId))!;
}