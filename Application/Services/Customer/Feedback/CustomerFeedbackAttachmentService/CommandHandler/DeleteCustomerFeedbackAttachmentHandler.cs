namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.CommandHandler;

public readonly struct DeleteCustomerFeedbackAttachmentHandler : IRequestHandler<DeleteCustomerFeedbackAttachmentCommand, Result<CustomerFeedbackAttachmentResponse>>
{
    private readonly ICustomerFeedbackAttachmentRepository _repository;

    public DeleteCustomerFeedbackAttachmentHandler(ICustomerFeedbackAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackAttachmentResponse>> Handle(DeleteCustomerFeedbackAttachmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerFeedbackAttachmentAsync(request.Id))
                .Match(result => new Result<CustomerFeedbackAttachmentResponse>(result),
                    exception => new Result<CustomerFeedbackAttachmentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new Exception(e.Message));
        }
    }
}