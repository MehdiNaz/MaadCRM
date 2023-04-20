namespace Application.Services.CustomerActivityService.Commands;

public struct DeleteCustomerActivityCommand : IRequest<CustomerActivity>
{
    public Ulid Id { get; set; }
}