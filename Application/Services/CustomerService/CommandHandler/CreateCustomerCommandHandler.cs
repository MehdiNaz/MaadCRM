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
            BirthDayDate = request.BirthDayDate,
            CustomerPic = request.CustomerPic,
            CreatedBy = request.CreatedBy,
            UpdatedBy = request.UpdatedBy,
            CityId = request.CityId,
            UserId = request.UserId!,
            BusinessId = request.BusinessId,
            CustomerCategoryId = request.CustomerCategoryId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId,
        };
        await _repository.CreateCustomerAsync(item);
        return item;
    }
}
