namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct AllCustomerCategoryHandler : IRequestHandler<AllItemsCustomerCategoryQuery, Result<ICollection<CustomerCategory>>>
{
    private readonly ICustomerCategoryRepository _repository;

    public AllCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerCategory>>> Handle(AllItemsCustomerCategoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerCategoryAsync(request.UserId)).Match(result => new Result<ICollection<CustomerCategory>>(result), exception => new Result<ICollection<CustomerCategory>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerCategory>>(new Exception(e.Message));
        }
    }
}