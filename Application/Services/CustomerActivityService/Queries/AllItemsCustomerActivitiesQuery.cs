namespace Application.Services.CustomerActivityService.Queries;

public struct AllItemsCustomerActivitiesQuery : IRequest<ICollection<CustomerActivity>>
{
    public Ulid CustomerId { get; set; }
}