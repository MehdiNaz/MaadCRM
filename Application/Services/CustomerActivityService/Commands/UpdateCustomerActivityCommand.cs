namespace Application.Services.CustomerActivityService.Commands;

public struct UpdateCustomerActivityCommand : IRequest<CustomerActivity>
{
    public Ulid CustomerActivityId { get; set; }
    public string CustomerActivityName { get; set; }
    public string CustomerActivityDescription { get; set; }
    public Ulid CustomerId { get; set; }
}