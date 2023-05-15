namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct ChangeStatusCustomerPeyGiryCommandHandler : IRequestHandler<ChangeStatusCustomerPeyGiryCommand, Result<CustomerPeyGiryResponse>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public ChangeStatusCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiryResponse>> Handle(ChangeStatusCustomerPeyGiryCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerPeyGiryByIdAsync(request))
                .Match(result => new Result<CustomerPeyGiryResponse>(result), exception => new Result<CustomerPeyGiryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiryResponse>(new Exception(e.Message));
        }
    }
}