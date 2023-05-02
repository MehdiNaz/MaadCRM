namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct UpdateCustomerCategoryCommandHandlers : IRequestHandler<UpdateCustomerCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public UpdateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerCategoryCommand customerCategory = new()
            {
                Id = request.Id,
                CustomerCategoryName = request.CustomerCategoryName,
                UserId = request.UserId
            };
            return (await _repository.UpdateCustomerCategoryAsync(customerCategory))
                .Match(result => new Result<CustomerFeedbackCategory>(result),
                    exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}
