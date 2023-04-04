namespace Application.Services.CustomerService.CommandHandler;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
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
            BirthDayDate = request.BirthDayDate,
            CustomerPic = request.CustomerPic,
            InsertedBy = request.InsertedBy,
            UpdatedBy = request.UpdatedBy,
            CityId = request.CityId,
            UserId = request.UserId,
            BusinessId = request.BusinessId,
            CustomerCategoryId = request.CustomerCategoryId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
        };
        await _repository.CreateCustomerAsync(item);
        return item;
    }
}
