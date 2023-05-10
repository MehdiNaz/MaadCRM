namespace Application.Services.Customer.Foroosh.ForoshOrderService.QueryHandler;

public readonly struct GetForooshOrderByIdHandler : IRequestHandler<GetForooshOrderByIdQuery, Result<ForooshOrder>>
{
    private readonly IForooshOrderRepository _repository;

    public GetForooshOrderByIdHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ForooshOrder>> Handle(GetForooshOrderByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetForooshOrderByIdAsync(request.ForooshOrderId))
                .Match(result => new Result<ForooshOrder>(result),
                    exception => new Result<ForooshOrder>(exception));
        }
        catch (Exception e)
        {
            return new Result<ForooshOrder>(new Exception(e.Message));
        }
    }
}