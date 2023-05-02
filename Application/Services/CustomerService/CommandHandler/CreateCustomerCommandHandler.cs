namespace Application.Services.CustomerService.CommandHandler;

public readonly struct CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = new CreateCustomerCommand
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDayDate = request.BirthDayDate!,
                CustomerPic = request.CustomerPic,
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
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };
             (await _repository.CreateCustomerAsync(item)).Match(result =>
             {
                 return new Result<CustomerResponse>(result);
             }, exception =>
             {
                 return new Result<CustomerResponse>(exception);
             });
             
            return new Result<CustomerResponse>(new Exception("Error"));
            // return (await _repository.CreateCustomerAsync(item)).Match(result => new Result<CustomerResponse>(result), exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}
