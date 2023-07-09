namespace Application.Services.SpecialFields.AttributeCustomerService.Queries;

public struct AllAttributesCustomerQuery : IRequest<Result<ICollection<AttributeCustomerResponse>>>
{
    public string IdUser { get; set; }
    public Ulid IdCustomer { get; set; }
}