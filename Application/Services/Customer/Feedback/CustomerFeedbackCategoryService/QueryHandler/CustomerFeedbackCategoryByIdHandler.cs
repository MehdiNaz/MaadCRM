namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.QueryHandler;

public readonly struct CustomerFeedbackCategoryByIdHandler : IRequestHandler<CustomerFeedbackCategoryByIdQuery, Result<CustomerFeedbackCategoryResponse>>
{
    readonly ICustomerFeedbackCategoryRepository _repository;

    public CustomerFeedbackCategoryByIdHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategoryResponse>> Handle(CustomerFeedbackCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerFeedbackCategoryByIdAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackCategoryResponse>(result),
                    exception => new Result<CustomerFeedbackCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new Exception(e.Message));
        }
    }
}
