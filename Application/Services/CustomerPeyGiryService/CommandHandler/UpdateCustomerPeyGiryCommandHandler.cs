namespace Application.Services.CustomerPeyGiryService.CommandHandler;

public readonly struct UpdateCustomerPeyGiryCommandHandler : IRequestHandler<UpdateCustomerPeyGiryCommand, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public UpdateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry> Handle(UpdateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerPeyGiryCommand item = new()
        {
            Id = request.Id,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        return await _repository.UpdateCustomerPeyGiryAsync(item);
    }
}