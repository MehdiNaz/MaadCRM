namespace Application.Services.ProductService.CommandHandler;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteProductAsync(request.ProductId))!;
}