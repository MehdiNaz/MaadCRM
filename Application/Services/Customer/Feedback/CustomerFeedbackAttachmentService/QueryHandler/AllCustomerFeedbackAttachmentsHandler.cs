namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.QueryHandler;

public readonly struct AllCustomerFeedbackAttachmentsHandler : IRequestHandler<AllCustomerFeedbackAttachmentsQuery, Result<ICollection<CustomerFeedbackAttachmentResponse>>>
{
    private readonly ICustomerFeedbackAttachmentRepository _repository;

    public AllCustomerFeedbackAttachmentsHandler(ICustomerFeedbackAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<CustomerFeedbackAttachmentResponse>>> Handle(AllCustomerFeedbackAttachmentsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllCustomerFeedbackAttachmentAsync(request.CustomerFeedbackId))
                .Match(result => new Result<ICollection<CustomerFeedbackAttachmentResponse>>(result),
                    exception => new Result<ICollection<CustomerFeedbackAttachmentResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<CustomerFeedbackAttachmentResponse>>(new Exception(e.Message));
        }
    }
}