namespace Application.Services.ProductService.CommandHandler;

public readonly struct ChangeStatusProductByIdCommandHandler : IRequestHandler<ChangeStatusProductByIdCommand, Product>
{
    private readonly IProductRepository _repository;

    public ChangeStatusProductByIdCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(ChangeStatusProductByIdCommand request, CancellationToken cancellationToken)
        => (await _repository.ChangeStatusProductByIdAsync(request.ProductStatus, request.ProductId))!;
}