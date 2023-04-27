namespace Application.Services.BusinessService.Queries;

public struct GetBusinessNameByUserIdQuery : IRequest<Result<ICollection<Business>>>
{
    public string UserId { get; set; }
}