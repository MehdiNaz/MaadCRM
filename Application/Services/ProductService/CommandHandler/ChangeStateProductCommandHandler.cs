namespace Application.Services.ProductService.CommandHandler;

public readonly struct ChangeStateProductCommandHandler : IRequestHandler<ChangeStateProductCommand, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public ChangeStateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(ChangeStateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusProductAsync(request))
                .Match(result => new Result<ProductResponse>(result),
                    exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}