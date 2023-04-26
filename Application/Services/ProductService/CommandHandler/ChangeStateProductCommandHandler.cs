namespace Application.Services.ProductService.CommandHandler;

public readonly struct ChangeStateProductCommandHandler : IRequestHandler<ChangeStateProductCommand, Result<Product>>
{
    private readonly IProductRepository _repository;

    public ChangeStateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Product>> Handle(ChangeStateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusProductAsync(request)).Match(result => new Result<Product>(result), exception => new Result<Product>(exception));
        }
        catch (Exception e)
        {
            return new Result<Product>(new Exception(e.Message));
        }
    }
}