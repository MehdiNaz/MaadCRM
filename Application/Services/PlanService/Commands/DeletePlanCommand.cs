namespace Application.Services.PlanService.Commands;

public struct DeletePlanCommand : IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}