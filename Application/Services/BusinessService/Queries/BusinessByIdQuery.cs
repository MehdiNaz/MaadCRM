namespace Application.Services.BusinessService.Queries;

public struct BusinessByIdQuery : IRequest<Result<Business>>
{
    public Ulid BusinessId { get; set; }
}