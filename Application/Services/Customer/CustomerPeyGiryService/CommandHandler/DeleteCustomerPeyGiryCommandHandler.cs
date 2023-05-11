namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct DeleteCustomerPeyGiryCommandHandler : IRequestHandler<DeleteCustomerPeyGiryCommand, Result<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public DeleteCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiry>> Handle(DeleteCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteCustomerPeyGiryAsync(request.Id))
                .Match(result => new Result<CustomerPeyGiry>(result), exception => new Result<CustomerPeyGiry>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new Exception(e.Message));
        }
    }
}