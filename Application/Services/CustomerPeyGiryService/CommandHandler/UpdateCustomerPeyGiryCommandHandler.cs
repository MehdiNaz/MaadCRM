namespace Application.Services.CustomerPeyGiryService.CommandHandler;

public readonly struct UpdateCustomerPeyGiryCommandHandler : IRequestHandler<UpdateCustomerPeyGiryCommand, Result<CustomerPeyGiry>>
{
    private readonly ICustomerPeyGiryRepository _repository;

    public UpdateCustomerPeyGiryCommandHandler(ICustomerPeyGiryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerPeyGiry>> Handle(UpdateCustomerPeyGiryCommand request, CancellationToken cancellationToken)
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
                .Match(result => new Result<CustomerPeyGiry>(result), exception => new Result<CustomerPeyGiry>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerPeyGiry>(new Exception(e.Message));
        }
    }
}