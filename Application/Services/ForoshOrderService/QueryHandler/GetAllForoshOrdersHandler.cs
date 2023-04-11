namespace Application.Services.ForoshOrderService.QueryHandler;

public readonly struct GetAllForoshOrdersHandler : IRequestHandler<GetAllForoshOrdersQuery, ICollection<ForoshOrder?>>
{
    private readonly IForoshOrderRepository _repository;

    public GetAllForoshOrdersHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ForoshOrder?>> Handle(GetAllForoshOrdersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllForoshOrdersAsync();
}