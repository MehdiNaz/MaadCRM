namespace Application.Services.ForoshOrderService.QueryHandler;

public class GetAllForoshOrdersHandler : IRequestHandler<GetAllForoshOrdersQuery, ICollection<ForoshOrder?>>
{
    private readonly IForoshOrderRepository _repository;

    public GetAllForoshOrdersHandler(IForoshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ForoshOrder?>> Handle(GetAllForoshOrdersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllForoshOrdersAsync();
}