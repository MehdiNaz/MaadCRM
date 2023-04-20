namespace Application.Services.CustomerFeedbackService.CommandHandlers;

public readonly struct CreateCustomerFeedBackCommandHandlers : IRequestHandler<CreateCustomerFeedBackCommand, CustomerFeedback>
{
    private readonly ICustomerFeedbackRepository _repository;

    public CreateCustomerFeedBackCommandHandlers(ICustomerFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerFeedback> Handle(CreateCustomerFeedBackCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerFeedBackCommand item = new()
        {
            FeedbackName = request.FeedbackName,
            DisplayOrder = request.DisplayOrder,
            Point = request.Point,
            BalancePoint = request.BalancePoint
        };
        return await _repository.CreateCustomerFeedbackAsync(item);
    }
}