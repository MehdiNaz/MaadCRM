namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.QueryHandler;

public readonly struct AllCustomerFeedbackCategoriesHandler : IRequestHandler<AllCustomerFeedbackCategoriesQuery, Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public AllCustomerFeedbackCategoriesHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackCategoryResponse>>> Handle(AllCustomerFeedbackCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerFeedbackCategoriesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<CustomerFeedbackCategoryResponse>>(result),
                    exception => new Result<ICollection<CustomerFeedbackCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategoryResponse>>(new Exception(e.Message));
        }
    }
}