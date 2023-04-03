namespace Application.Services.PeyGiryService.CommandHandler;

public class DeleteCustomerPeyGiryCommandHandler : IRequestHandler<DeleteCustomerPeyGiryCommand, CustomerPeyGiry>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public DeleteCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry?> Handle(DeleteCustomerPeyGiryCommand request, CancellationToken cancellationToken)
        => await _repository.DeleteCustomerPeyGiryAsync(request.CustomerPeyGiryId);
}