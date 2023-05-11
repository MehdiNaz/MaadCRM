namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct ChangeStatusCustomerPeyGiryCommandHandler : IRequestHandler<ChangeStatusCustomerPeyGiryCommand, Result<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public ChangeStatusCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiry>> Handle(ChangeStatusCustomerPeyGiryCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusCustomerPeyGiryByIdAsync(request))
                .Match(result => new Result<CustomerPeyGiry>(result), exception => new Result<CustomerPeyGiry>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new Exception(e.Message));
        }
    }
}