namespace Application.Services.PlanValidation.Commands;

public abstract class UpdatePlanCommand : RequestPlan, IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}