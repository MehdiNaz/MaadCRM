namespace Application.Services.Customer.Foroosh.ForoshOrderService.Queries;

public struct GetAllForooshOrdersQuery : IRequest<Result<ICollection<ForooshOrder>>>
{
}