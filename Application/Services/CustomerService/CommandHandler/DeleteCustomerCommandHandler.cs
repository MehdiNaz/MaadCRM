namespace Application.Services.CustomerService.CommandHandler;

public readonly struct DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;

    public DeleteCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = (await _repository.DeleteCustomerAsync(request.CustomerId))!;
        return result.Select(x => new CustomerResponse
        {
            Address = x.Address,
            FirstName = x.FirstName,
            LastName = x.LastName,
            BirthDayDate = x.BirthDayDate,
            CustomerCategoryId = x.CustomerCategoryId,
            CustomerId = x.CustomerId,
            From = x.From,
            CustomerState = x.CustomerState,
            UpTo = x.UpTo,
            EmailAddress = x.EmailAddress,
            MoshtaryMoAref = x.MoshtaryMoAref,
            PhoneNumber = x.PhoneNumber,
            CityId = x.CityId,
            Gender = x.Gender
        });
    }
}