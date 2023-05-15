namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct DeleteCustomerPeyGiryCommandHandler : IRequestHandler<DeleteCustomerPeyGiryCommand, Result<CustomerPeyGiryResponse>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public DeleteCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiryResponse>> Handle(DeleteCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerPeyGiryAsync(request.Id))
                .Match(result => new Result<CustomerPeyGiryResponse>(result),
                    exception => new Result<CustomerPeyGiryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiryResponse>(new Exception(e.Message));
        }
    }
}