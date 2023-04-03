namespace Application.Services.PeyGiryService.CommandHandler;

public class CreateCustomerPeyGiryCommandHandler : IRequestHandler<CreateCustomerPeyGiryCommand, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CreateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry> Handle(CreateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        CustomerPeyGiry item = new()
        {
            Description = request.Description,
            CustomerId = request.CustomerId
        };
        await _repository.CreateCustomerPeyGiryAsync(item);
        return item;
    }
}