namespace Application.Services.PlanService.Commands;

public abstract class DeletePlanCommand : IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}