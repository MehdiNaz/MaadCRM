using Domain.Models.Businesses.Plans;

namespace Application.Services.PlanService.Commands;

public struct ChangeStatusPlanCommand : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
    public StatusType PlanStatusType { get; set; }
}