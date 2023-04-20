namespace Application.Services.CustomerActivityService.CommandHandlers;

public readonly struct CreateCustomerActivityCommandHandler : IRequestHandler<CreateCustomerActivityCommand, CustomerActivity>
{
    private readonly ICustomerActivityRepository _repository;

    public CreateCustomerActivityCommandHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerActivity> Handle(CreateCustomerActivityCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerActivityCommand item = new()
        {
            CustomerActivityName = request.CustomerActivityName,
            CustomerActivityDescription = request.CustomerActivityDescription,
            CustomerId = request.CustomerId
        };
        return await _repository.CreateCustomerActivityAsync(item);
    }
}