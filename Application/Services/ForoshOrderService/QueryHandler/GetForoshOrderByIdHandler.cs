namespace Application.Services.ForoshOrderService.QueryHandler;

public readonly struct GetForoshOrderByIdHandler : IRequestHandler<GetForoshOrderByIdQuery, ForooshOrder?>
{
    private readonly IForoshOrderRepository _repository;

    public GetForoshOrderByIdHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder?> Handle(GetForoshOrderByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetForoshOrderByIdAsync(request.ForoshOrderId);
}