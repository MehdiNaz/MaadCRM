namespace Application.Services.PlanService.Commands;

public abstract class UpdatePlanCommand : RequestPlan, IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}