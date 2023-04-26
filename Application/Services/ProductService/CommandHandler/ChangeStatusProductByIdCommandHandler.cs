namespace Application.Services.ProductService.CommandHandler;

public readonly struct ChangeStatusProductByIdCommandHandler : IRequestHandler<ChangeStatusProductByIdCommand, Result<Product>>
{
    private readonly IProductRepository _repository;

    public ChangeStatusProductByIdCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> Handle(ChangeStatusProductByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusProductByIdAsync(request.ProductStatus, request.ProductId)).Match(result => new Result<Product>(result), exception => new Result<Product>(exception));
        }
        catch (Exception e)
        {
            return new Result<Product>(new Exception(e.Message));
        }
    }
}