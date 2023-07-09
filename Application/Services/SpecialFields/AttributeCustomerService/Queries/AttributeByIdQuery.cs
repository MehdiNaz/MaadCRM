namespace Application.Services.SpecialFields.AttributeCustomerService.Queries;

public struct AttributeCustomerByIdQuery : IRequest<Result<AttributeCustomerResponse>>
{
    public Ulid Id { get; set; }
}