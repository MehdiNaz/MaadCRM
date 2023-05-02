namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct CreateCustomerCategoryCommandHandlers : IRequestHandler<CreateCustomerCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public CreateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerCategoryCommand customerCategory = new()
            {
                UserId = request.UserId,
                CustomerCategoryName = request.CustomerCategoryName
            };
            return (await _repository.CreateCustomerCategoryAsync(customerCategory)).Match(result => new Result<CustomerFeedbackCategory>(result), exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}
