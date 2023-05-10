namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.QueryHandler;

public readonly struct SearchByFeedbackTypeNameHandler : IRequestHandler<SearchByFeedbackTypeNameQuery, Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public SearchByFeedbackTypeNameHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackCategoryResponse>>> Handle(SearchByFeedbackTypeNameQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByFeedbackTypeNameAsync(request.Type))
                .Match(result => new Result<ICollection<CustomerFeedbackCategoryResponse>>(result),
                    exception => new Result<ICollection<CustomerFeedbackCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategoryResponse>>(new Exception(e.Message));
        }
    }
}