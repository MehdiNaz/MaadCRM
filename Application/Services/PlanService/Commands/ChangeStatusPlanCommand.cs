namespace Application.Services.PlanService.Commands;

public struct ChangeStatusPlanCommand : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
    public Status PlanStatus { get; set; }
}