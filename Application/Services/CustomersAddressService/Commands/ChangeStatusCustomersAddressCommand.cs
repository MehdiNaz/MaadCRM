namespace Application.Services.CustomersAddressService.Commands;

public struct ChangeStatusCustomersAddressCommand : IRequest<CustomerAddress?>
{
    public Ulid Id { get; set; }
    public StatusType CustomersAddressStatusType { get; set; }
    public string IdUser { get; set; }
}