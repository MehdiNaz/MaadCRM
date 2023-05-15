namespace Application.Services.Customer.CustomerPeyGiryService.CommandHandler;

public readonly struct CreateCustomerPeyGiryCommandHandler : IRequestHandler<CreateCustomerPeyGiryCommand, Result<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public CreateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiry>> Handle(CreateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerPeyGiryCommand item = new()
            {
                Description = request.Description,
                DatePeyGiry = request.DatePeyGiry,
                CustomerId = request.CustomerId,
                IdUser = request.IdUser,
                IdPeyGiryCategory = request.IdPeyGiryCategory
            };
            return (await _repository.CreateCustomerPeyGiryAsync(item)).Match(result => new Result<CustomerPeyGiry>(result), exception => new Result<CustomerPeyGiry>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new Exception(e.Message));
        }
    }
}