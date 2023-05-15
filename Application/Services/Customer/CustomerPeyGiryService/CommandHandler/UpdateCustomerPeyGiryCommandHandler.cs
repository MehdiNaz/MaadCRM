namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct UpdateCustomerPeyGiryCommandHandler : IRequestHandler<UpdateCustomerPeyGiryCommand, Result<CustomerPeyGiryResponse>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public UpdateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiryResponse>> Handle(UpdateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerPeyGiryCommand item = new()
            {
                Id = request.Id,
                Description = request.Description,
                DatePeyGiry = request.DatePeyGiry,
                IdUser = request.IdUser
            };
            return (await _repository.UpdateCustomerPeyGiryAsync(item))
                .Match(result => new Result<CustomerPeyGiryResponse>(result),
                    exception => new Result<CustomerPeyGiryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiryResponse>(new Exception(e.Message));
        }
    }
}