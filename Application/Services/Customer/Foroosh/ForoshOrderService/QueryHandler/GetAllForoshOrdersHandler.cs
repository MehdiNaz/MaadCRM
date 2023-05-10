namespace Application.Services.Customer.Foroosh.ForoshOrderService.QueryHandler;

public readonly struct GetAllForooshOrdersHandler : IRequestHandler<GetAllForooshOrdersQuery, Result<ICollection<ForooshOrder>>>
{
    private readonly IForooshOrderRepository _repository;

    public GetAllForooshOrdersHandler(IForooshOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<ForooshOrder>>> Handle(GetAllForooshOrdersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllForooshOrdersAsync())
                .Match(result => new Result<ICollection<ForooshOrder>>(result),
                    exception => new Result<ICollection<ForooshOrder>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<ForooshOrder>>(new Exception(e.Message));
        }
    }
}