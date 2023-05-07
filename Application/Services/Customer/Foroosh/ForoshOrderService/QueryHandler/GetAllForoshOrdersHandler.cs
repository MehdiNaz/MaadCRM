using Application.Services.Customer.Foroosh.ForooshOrderService.Queries;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.QueryHandler;

public readonly struct GetAllForooshOrdersHandler : IRequestHandler<GetAllForooshOrdersQuery, ICollection<ForooshOrder?>>
{
    private readonly IForooshOrderRepository _repository;

    public GetAllForooshOrdersHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<ForooshOrder?>> Handle(GetAllForooshOrdersQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllForooshOrdersAsync();
}