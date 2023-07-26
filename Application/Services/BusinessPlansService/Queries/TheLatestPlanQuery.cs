using Domain.Models.Businesses.Plans;

namespace Application.Services.BusinessPlansService.Queries;

public struct TheLatestPlanQuery : IRequest<Result<BusinessPlan>>
{
    public Ulid BusinessId { get; set; }
}