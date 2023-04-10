using Domain.Models.Customers;
using Domain.Models.Customers.Notes;

namespace Application.Services.CustomerService.CommandHandler;

public readonly struct CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public CreateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate!,
            CustomerPic = request.CustomerPic,
            // CreatedBy = request.CreatedBy!,
            // UpdatedBy = request.UpdatedBy,
            CustomerCategoryId = request.CustomerCategoryId,
            // UserId = request.UserId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
            PhoneNumbers = request.PhoneNumbers,
            EmailAddresses = request.EmailAddresses,
            FavoritesLists = request.FavoritesLists,
            CustomersAddresses = request.CustomersAddresses,
            CustomerNotes = request.CustomerNotes,
            CustomerPeyGiries = request.CustomerPeyGiries,
            City = request.City
        };
        await _repository.CreateCustomerAsync(item);
        return item;
    }
}
