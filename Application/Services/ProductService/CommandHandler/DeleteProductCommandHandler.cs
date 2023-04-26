namespace Application.Services.ProductService.CommandHandler;

public readonly struct DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Product>>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteProductAsync(request)).Match(result => new Result<Product>(result), exception => new Result<Product>(exception));
        }
        catch (Exception e)
        {
            return new Result<Product>(new Exception(e.Message));
        }
    }
}