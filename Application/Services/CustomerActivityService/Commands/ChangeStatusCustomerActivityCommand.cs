namespace Application.Services.CustomerActivityService.Commands;

public struct ChangeStatusCustomerActivityCommand : IRequest<CustomerActivity?>
{
    public Ulid CustomerActivityId { get; set; }
    public Status CustomerActivityStatus { get; set; }
}