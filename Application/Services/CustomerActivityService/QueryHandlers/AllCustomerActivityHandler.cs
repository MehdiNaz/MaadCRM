namespace Application.Services.CustomerActivityService.QueryHandlers;

public readonly struct AllCustomerActivityHandler : IRequestHandler<AllItemsCustomerActivitiesQuery, ICollection<CustomerActivity>>
{
    private readonly ICustomerActivityRepository _repository;

    public AllCustomerActivityHandler(ICustomerActivityRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerActivity>> Handle(AllItemsCustomerActivitiesQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllCustomerActivitiesAsync(request.CustomerId);
}