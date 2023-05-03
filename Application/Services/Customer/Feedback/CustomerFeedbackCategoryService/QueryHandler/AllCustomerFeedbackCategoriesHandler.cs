namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.QueryHandler;

public readonly struct AllCustomerFeedbackCategoriesHandler : IRequestHandler<AllCustomerFeedbackCategoriesQuery, Result<ICollection<CustomerFeedbackCategory>>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public AllCustomerFeedbackCategoriesHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackCategory>>> Handle(AllCustomerFeedbackCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerFeedbackCategoriesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<CustomerFeedbackCategory>>(result),
                    exception => new Result<ICollection<CustomerFeedbackCategory>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategory>>(new Exception(e.Message));
        }
    }
}