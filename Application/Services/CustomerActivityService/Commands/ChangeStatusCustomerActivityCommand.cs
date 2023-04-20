namespace Application.Services.CustomerActivityService.Commands;

public struct ChangeStatusCustomerActivityCommand : IRequest<CustomerActivity?>
{
    public Ulid Id { get; set; }
    public Status CustomerActivityStatus { get; set; }
}