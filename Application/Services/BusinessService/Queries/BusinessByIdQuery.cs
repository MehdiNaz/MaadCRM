namespace Application.Services.BusinessService.Queries;

public struct BusinessByIdQuery : IRequest<Business>
{
    public Ulid BusinessId { get; set; }
}