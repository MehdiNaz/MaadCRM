using Domain.Models.Businesses.Plans;

namespace Application.Services.PlanService.Queries;

public struct AllPlansQuery : IRequest<ICollection<Plan?>>
{
}