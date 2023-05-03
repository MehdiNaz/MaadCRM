namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct CreateCustomerFeedbackCategoryCommandHandler : IRequestHandler<CreateCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategory>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public CreateCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategory>> Handle(CreateCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerFeedbackCategoryCommand item = new()
            {
                Name = request.Name,
                IdBusiness = request.IdBusiness,
                PositiveNegative = request.PositiveNegative,
                TypeFeedback = request.TypeFeedback
            };

            return (await _repository.CreateCustomerFeedbackCategoryAsync(item))
                .Match(result => new Result<CustomerFeedbackCategory>(result),
                    exception => new Result<CustomerFeedbackCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategory>(new Exception(e.Message));
        }
    }
}