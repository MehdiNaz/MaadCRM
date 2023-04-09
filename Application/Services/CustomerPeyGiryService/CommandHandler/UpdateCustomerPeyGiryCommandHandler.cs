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
        CustomerPeyGiry item = new()
        {
            CustomerPeyGiryId = request.CustomerPeyGiryId,
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateCustomerPeyGiryAsync(item);
        return item;
    }
}