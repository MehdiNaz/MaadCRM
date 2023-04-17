namespace Application.Services.CustomerService.CommandHandler;

public readonly struct UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerResponse?>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerResponse?> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var item = new UpdateCustomerCommand
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate!,
            CustomerPic = request.CustomerPic,
            // CreatedBy = request.CreatedBy!,
            // UpdatedBy = request.UpdatedBy,
            CustomerCategoryId = request.CustomerCategoryId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
            PhoneNumbers = request.PhoneNumbers,
            EmailAddresses = request.EmailAddresses,
            FavoritesLists = request.FavoritesLists!,
            CustomersAddresses = request.CustomersAddresses,
            CustomerNotes = request.CustomerNotes,
            CustomerPeyGiries = request.CustomerPeyGiries,
            CityId = request.CityId
        };
        var result = await _repository.UpdateCustomerAsync(item);
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