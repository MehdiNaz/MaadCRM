namespace Application.Services.BusinessService.Queries;

public struct BusinessByIdQuery : IRequest<Result<Business>>
{
    public Ulid Id { get; set; }
}