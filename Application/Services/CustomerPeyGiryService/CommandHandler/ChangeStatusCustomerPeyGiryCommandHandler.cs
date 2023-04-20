namespace Application.Services.CustomerPeyGiryService.CommandHandler;

public readonly struct ChangeStatusCustomerPeyGiryCommandHandler : IRequestHandler<ChangeStatusCustomerPeyGiryCommand, CustomerPeyGiry?>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public ChangeStatusCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPeyGiry?> Handle(ChangeStatusCustomerPeyGiryCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusCustomerPeyGiryByIdAsync(request);
}