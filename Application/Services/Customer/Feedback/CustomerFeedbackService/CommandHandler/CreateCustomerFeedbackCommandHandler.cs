namespace Application.Services.Customer.Feedback.CustomerFeedbackService.CommandHandler;

public readonly struct CreateCustomerFeedbackCommandHandler : IRequestHandler<CreateCustomerFeedbackCommand, Result<CustomerFeedback>>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CreateCustomerFeedbackCommandHandler(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedback>> Handle(CreateCustomerFeedbackCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerFeedbackCommand item = new()
            {
                Description = request.Description,
                IdCategory = request.IdCategory,
                IdCustomer = request.IdCustomer,
                IdProduct = request.IdProduct
            };

            return (await _repository.CreateCustomerFeedbackAsync(item))
                .Match(result => new Result<CustomerFeedback>(result),
                    exception => new Result<CustomerFeedback>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedback>(new Exception(e.Message));
        }
    }
}