using Application.Services.Customer.Foroosh.ForooshOrderService.Queries;

namespace Application.Services.Customer.Foroosh.ForooshOrderService.QueryHandler;

public readonly struct GetForooshOrderByIdHandler : IRequestHandler<GetForooshOrderByIdQuery, ForooshOrder?>
{
    private readonly IForooshOrderRepository _repository;

    public GetForooshOrderByIdHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<ForooshOrder?> Handle(GetForooshOrderByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetForooshOrderByIdAsync(request.ForooshOrderId);
}