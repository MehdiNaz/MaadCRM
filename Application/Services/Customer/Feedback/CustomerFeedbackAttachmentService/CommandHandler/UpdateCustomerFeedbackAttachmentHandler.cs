namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.CommandHandler;

public readonly struct UpdateCustomerFeedbackAttachmentHandler : IRequestHandler<UpdateCustomerFeedbackAttachmentCommand, Result<CustomerFeedbackAttachmentResponse>>
{
    private readonly ICustomerFeedbackAttachmentRepository _repository;

    public UpdateCustomerFeedbackAttachmentHandler(ICustomerFeedbackAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackAttachmentResponse>> Handle(UpdateCustomerFeedbackAttachmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerFeedbackAttachmentCommand item = new()
            {
                Id = request.Id,
                Name = request.Name,
                Extenstion = request.Extenstion,
                IdCustomerFeedback = request.IdCustomerFeedback,
                FileName = request.FileName
            };

            return (await _repository.UpdateCustomerFeedbackAttachmentAsync(item))
                .Match(result => new Result<CustomerFeedbackAttachmentResponse>(result),
                    exception => new Result<CustomerFeedbackAttachmentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new Exception(e.Message));
        }
    }
}