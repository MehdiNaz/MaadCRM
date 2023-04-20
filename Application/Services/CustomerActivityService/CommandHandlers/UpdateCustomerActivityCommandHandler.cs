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
        UpdateCustomerActivityCommand item = new()
        {
            Id = request.Id,
            CustomerActivityName = request.CustomerActivityName,
            CustomerActivityDescription = request.CustomerActivityDescription,
            CustomerId = request.CustomerId
        };
        return await _repository.UpdateCustomerActivityAsync(item);
    }
}