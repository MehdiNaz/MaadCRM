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
            Description = request.Description,
        };
        return await _repository.CreateCustomerFeedbackAsync(item);
    }
}