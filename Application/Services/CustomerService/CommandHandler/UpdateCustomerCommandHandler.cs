namespace Application.Services.CustomerService.CommandHandler;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerCommandHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer item = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate,
            CustomerPic = request.CustomerPic,
            UserId = request.UserId,
            BusinessId = request.BusinessId,
            CustomerCategoryId = request.CustomerCategoryId,
            Gender = request.Gender,
            IsShown = request.IsShown,
            CustomerState = request.CustomerState,
            CustomerStatus = request.CustomerStatus,
            InsertedBy = request.InsertedBy,
            UpdatedBy = request.UpdatedBy,
            IsDeleted = request.IsDeleted,
            CityId = request.CityId,
            CustomerMoarefId = request.CustomerMoarefId
        };
        await _repository.UpdateCustomerAsync(item, request.CustomerId);
        return item;
    }
}