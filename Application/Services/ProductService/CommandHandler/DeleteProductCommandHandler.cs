namespace Application.Services.ProductService.CommandHandler;

public readonly struct DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteProductAsync(request.Id))
                .Match(result => new Result<ProductResponse>(result),
                    exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}