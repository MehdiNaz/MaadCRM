namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct CreateCustomerFeedbackCommandHandler : IRequestHandler<CreateCustomerFeedbackCommand, Result<CustomerFeedbackResponse>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CreateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackResponse>> Handle(CreateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerFeedbackCommand item = new()
            {
                Description = request.Description,
                IdCategory = request.IdCategory,
                IdCustomer = request.IdCustomer,
                IdProduct = request.IdProduct,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated,
                IdUser = request.IdUser
            };

            return (await _repository.CreateCustomerFeedbackAsync(item))
                .Match(result => new Result<CustomerFeedbackResponse>(result),
                    exception => new Result<CustomerFeedbackResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackResponse>(new Exception(e.Message));
        }
    }
}