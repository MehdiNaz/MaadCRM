namespace Application.Services.CustomerActivityService.QueryHandlers;

public readonly struct CustomerActivityBuIdHandler : IRequestHandler<CustomerActivityByIdQuery, CustomerActivity>
{
    private readonly ICustomerActivityRepository _repository;

    public CustomerActivityBuIdHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerActivity> Handle(CustomerActivityByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetCustomerActivityByIdAsync(request.CustomerActivityId);
}