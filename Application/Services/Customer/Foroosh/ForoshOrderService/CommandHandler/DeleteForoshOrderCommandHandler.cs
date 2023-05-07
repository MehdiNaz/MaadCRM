using Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.CommandHandler;

public readonly struct DeleteForooshOrderCommandHandler : IRequestHandler<DeleteForooshOrderCommand, ForooshOrder>
{
    private readonly IForooshOrderRepository _repository;

    public DeleteForooshOrderCommandHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder> Handle(DeleteForooshOrderCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteForooshOrderAsync(request.Id))!;
}