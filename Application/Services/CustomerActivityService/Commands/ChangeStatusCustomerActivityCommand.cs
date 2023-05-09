namespace Application.Services.CustomerActivityService.Commands;

public struct ChangeStatusCustomerActivityCommand : IRequest<CustomerActivity?>
{
    public Ulid Id { get; set; }
    public StatusType CustomerActivityStatusType { get; set; }
}