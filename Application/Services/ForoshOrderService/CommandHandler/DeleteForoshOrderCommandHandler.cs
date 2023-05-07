namespace Application.Services.ForoshOrderService.CommandHandler;

public readonly struct DeleteForoshOrderCommandHandler : IRequestHandler<DeleteForoshOrderCommand, ForooshOrder>
{
    private readonly IForoshOrderRepository _repository;

    public DeleteForoshOrderCommandHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(DeleteForoshOrderCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteForoshOrderAsync(request.Id))!;
}