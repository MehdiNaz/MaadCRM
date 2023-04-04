namespace Application.Services.ProductService.CommandHandler;

public class ChangeStateProductCommandHandler : IRequestHandler<ChangeStateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public ChangeStateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(ChangeStateProductCommand request, CancellationToken cancellationToken)
        => (await _repository.ChangeStateProductAsync(request.Status, request.ProductId))!;
}