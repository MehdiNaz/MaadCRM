using Domain.Models.Businesses.Plans;

namespace Application.Services.PlanService.Commands;

public struct DeletePlanCommand : IRequest<Plan>
{
    public Ulid Id { get; set; }
}