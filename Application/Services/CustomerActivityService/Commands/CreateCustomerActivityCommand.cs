namespace Application.Services.CustomerActivityService.Commands;

public struct CreateCustomerActivityCommand : IRequest<CustomerActivity>
{
    public string CustomerActivityName { get; set; }
    public string CustomerActivityDescription { get; set; }
    public Ulid CustomerId { get; set; }
}