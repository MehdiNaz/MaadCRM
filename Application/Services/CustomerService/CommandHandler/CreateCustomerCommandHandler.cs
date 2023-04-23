namespace Application.Services.CustomerService.CommandHandler;

public readonly struct CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var item = new CreateCustomerCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate!,
            CustomerPic = request.CustomerPic,
            // CreatedBy = request.CreatedBy!,
            // UpdatedBy = request.UpdatedBy,
            CustomerCategoryId = request.CustomerCategoryId,
            UserId = request.UserId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
            PhoneNumbers = request.PhoneNumbers,
            EmailAddresses = request.EmailAddresses,
            FavoritesLists = request.FavoritesLists!,
            CustomersAddresses = request.CustomersAddresses,
            CustomerNotes = request.CustomerNotes,
            CustomerPeyGiries = request.CustomerPeyGiries,
            CityId = request.CityId,
            IdUserUpdated = request.IdUserUpdated,
            IdUserAdded = request.IdUserAdded
        };
        var result = await _repository.CreateCustomerAsync(item);
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
            Gender = x.Gender,
        });
    }
}
