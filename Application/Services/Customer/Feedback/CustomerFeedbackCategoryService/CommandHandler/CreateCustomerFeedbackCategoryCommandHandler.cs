namespace Application.Services.Customer.Feedback.CustomerFeedbackCategoryService.CommandHandler;

public readonly struct CreateCustomerFeedbackCategoryCommandHandler : IRequestHandler<CreateCustomerFeedbackCategoryCommand, Result<CustomerFeedbackCategoryResponse>>
{
    private readonly ICustomerFeedbackCategoryRepository _repository;

    public CreateCustomerFeedbackCategoryCommandHandler(ICustomerFeedbackCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackCategoryResponse>> Handle(CreateCustomerFeedbackCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerFeedbackCategoryCommand item = new()
            {
                Name = request.Name,
                IdBusiness = request.IdBusiness,
                PositiveNegative = request.PositiveNegative,
                TypeFeedback = request.TypeFeedback,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };

            return (await _repository.CreateCustomerFeedbackCategoryAsync(item))
                .Match(result => new Result<CustomerFeedbackCategoryResponse>(result),
                    exception => new Result<CustomerFeedbackCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackCategoryResponse>(new Exception(e.Message));
        }
    }
}