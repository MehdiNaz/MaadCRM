namespace Application.Services.Customer.Feedback.CustomerFeedbackAttachmentService.CommandHandler;

public readonly struct CreateCustomerFeedbackAttachmentHandler : IRequestHandler<CreateCustomerFeedbackAttachmentCommand, Result<CustomerFeedbackAttachmentResponse>>
{
    private readonly ICustomerFeedbackAttachmentRepository _repository;

    public CreateCustomerFeedbackAttachmentHandler(ICustomerFeedbackAttachmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerFeedbackAttachmentResponse>> Handle(CreateCustomerFeedbackAttachmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerFeedbackAttachmentCommand item = new()
            {
                Name = request.Name,
                Extenstion = request.Extenstion,
                IdCustomerFeedback = request.IdCustomerFeedback,
                FileName = request.FileName
            };

            return (await _repository.CreateCustomerFeedbackAttachmentAsync(item))
                .Match(result => new Result<CustomerFeedbackAttachmentResponse>(result),
                    exception => new Result<CustomerFeedbackAttachmentResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerFeedbackAttachmentResponse>(new Exception(e.Message));
        }
    }
}