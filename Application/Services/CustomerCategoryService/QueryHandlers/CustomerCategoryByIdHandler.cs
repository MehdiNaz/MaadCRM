namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct CustomerCategoryByIdHandler : IRequestHandler<CustomerCategoryByIdQuery, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public CustomerCategoryByIdHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(CustomerCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerCategoryByIdAsync(request.CustomerCategoryId, request.UserId)).Match(result => new Result<CustomerFeedbackCategory>(result), exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}