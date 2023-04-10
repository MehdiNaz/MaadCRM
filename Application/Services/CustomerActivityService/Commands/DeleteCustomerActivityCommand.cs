namespace Application.Services.CustomerActivityService.Commands;

public struct DeleteCustomerActivityCommand : IRequest<CustomerActivity>
{
    public Ulid CustomerActivityId { get; set; }
}