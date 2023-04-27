namespace Application.Services.BusinessService.Queries;

public struct GetBusinessByUserIdQuery : IRequest<Result<Business>>
{
    public string UserId { get; set; }
}