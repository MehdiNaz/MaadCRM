namespace Application.Services.ProductService.CommandHandler;

public readonly struct ChangeStatusProductByIdCommandHandler : IRequestHandler<ChangeStatusProductByIdCommand, Result<ProductResponse>>
{
    private readonly IProductRepository _repository;

    public ChangeStatusProductByIdCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductResponse>> Handle(ChangeStatusProductByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusProductByIdAsync(request.ProductStatusType, request.ProductId))
                .Match(result => new Result<ProductResponse>(result), exception => new Result<ProductResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<ProductResponse>(new Exception(e.Message));
        }
    }
}