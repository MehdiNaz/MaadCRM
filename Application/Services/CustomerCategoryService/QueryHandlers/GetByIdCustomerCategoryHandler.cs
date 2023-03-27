namespace Application.Services.CustomerCategoryService.QueryHandlers;

public class GetByIdCustomerCategoryHandler : IRequestHandler<GetByIdCustomerCategoryQuery, CustCategory?>
{
    private readonly ICustCategoryRepository _repository;

    public GetByIdCustomerCategoryHandler(ICustCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustCategory?> Handle(GetByIdCustomerCategoryQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustCategoryByIdAsync(request.CustCategoryId);
}