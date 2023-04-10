namespace Application.Services.CustomerActivityService.CommandHandlers;

public readonly struct UpdateCustomerActivityCommandHandler : IRequestHandler<UpdateCustomerActivityCommand, CustomerActivity>
{
    private readonly ICustomerActivityRepository _repository;

    public UpdateCustomerActivityCommandHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerActivity> Handle(UpdateCustomerActivityCommand request, CancellationToken cancellationToken)
    {
        CustomerActivity item = new()
        {
            CustomerActivityId = request.CustomerActivityId,
            CustomerActivityName = request.CustomerActivityName,
            CustomerActivityDescription = request.CustomerActivityDescription,
            CustomerId = request.CustomerId
        };
        await _repository.UpdateCustomerActivityAsync(item);
        return item;
    }
}