namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.QueryHandler;

public readonly struct CustomerCustomerFeedbackAttachmentByIdHandler : IRequestHandler<CustomerFeedbackAttachmentByIdQuery, Result<CustomerFeedbackAttachmentResponse>>
{
    private readonly ICustomerFeedbackAttachmentRepository _repository;

    public CustomerCustomerFeedbackAttachmentByIdHandler(ICustomerFeedbackAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackAttachmentResponse>> Handle(CustomerFeedbackAttachmentByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetCustomerFeedbackAttachmentByIdAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackAttachmentResponse>(result),
                    exception => new Result<CustomerFeedbackAttachmentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new Exception(e.Message));
        }
    }
}