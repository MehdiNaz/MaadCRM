namespace Application.Services.SpecialFields.CustomerAttributeService.Commands;

public struct CreateCustomerAttributeCommand : IRequest<Result<CustomerAttributeResponse>>
{
    public Ulid? IdAttributeOption { get; set; }
    public Ulid IdCustomer { get; set; }
}