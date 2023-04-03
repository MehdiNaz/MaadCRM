namespace Application.Services.PeyGiryService.CommandHandler;

public class UpdateCustomerPeyGiryCommandHandler : IRequestHandler<UpdateCustomerPeyGiryCommand, CustomerPeyGiry>
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
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateCustomerPeyGiryAsync(item, request.CustomerPeyGiryId);
        return item;
    }
}