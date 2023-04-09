namespace Application.Services.CustomerService.CommandHandler;

public readonly struct UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
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
            CustomerId = request.CustomerId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDayDate = request.BirthDayDate,
            CustomerPic = request.CustomerPic,
            CreatedBy = request.CreatedBy,
            UpdatedBy = request.UpdatedBy,
            CityId = request.CityId,
            UserId = request.UserId,
            CustomerCategoryId = request.CustomerCategoryId,
            Gender = request.Gender,
            CustomerMoarefId = request.CustomerMoarefId
        };
        await _repository.UpdateCustomerAsync(item);
        return item;
    }
}