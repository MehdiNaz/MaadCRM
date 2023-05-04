namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.QueryHandler;

public readonly struct CustomerFeedbackCategoryBySearchItemHandler : IRequestHandler<CustomerFeedbackCategoryBySearchItemQuery, Result<ICollection<CustomerFeedbackCategoryResponse>>>
{
    readonly ICustomerFeedbackCategoryRepository _repository;

    public CustomerFeedbackCategoryBySearchItemHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackCategoryResponse>>> Handle(CustomerFeedbackCategoryBySearchItemQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.SearchByItemsAsync(request.BusinessId,request.Q))
                .Match(result => new Result<ICollection<CustomerFeedbackCategoryResponse>>(result),
                    exception => new Result<ICollection<CustomerFeedbackCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackCategoryResponse>>(new Exception(e.Message));
        }
    }
}