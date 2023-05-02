namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct AllCustomerCategoryHandler : IRequestHandler<AllItemsCustomerCategoryQuery, Result<ICollection<CustomerFeedbackCategory>>>
{
    private readonly ICustomerCategoryRepository _repository;

    public AllCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackCategory>>> Handle(AllItemsCustomerCategoryQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerCategoryAsync(request.UserId)).Match(result => new Result<ICollection<CustomerFeedbackCategory>>(result), exception => new Result<ICollection<CustomerFeedbackCategory>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategory>>(new Exception(e.Message));
        }
    }
}