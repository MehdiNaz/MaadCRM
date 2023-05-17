using Application.Services.Customer.CustomerService.Commands;

namespace Application.Services.Customer.CustomerService.CommandHandler;

public readonly struct UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<CustomerResponse>>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerResponse>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var item = new UpdateCustomerCommand
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDayDate = request.BirthDayDate!,
                CustomerPic = request.CustomerPic,
                CustomerCategoryId = request.CustomerCategoryId,
                Gender = request.Gender,
                CustomerMoarefId = request.CustomerMoarefId,
                PhoneNumbers = request.PhoneNumbers,
                EmailAddresses = request.EmailAddresses,
                FavoritesLists = request.FavoritesLists!,
                CustomersAddresses = request.CustomersAddresses,
                CustomerNotes = request.CustomerNotes,
                CustomerPeyGiries = request.CustomerPeyGiries,
                CityId = request.CityId,
                IdUserUpdated = request.IdUserUpdated
            };
            return (await _repository.UpdateCustomerAsync(item)).Match(result => new Result<CustomerResponse>(result), exception => new Result<CustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerResponse>(new Exception(e.Message));
        }
    }
}