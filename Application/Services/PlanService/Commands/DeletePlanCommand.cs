namespace Application.Services.PlanService.Commands;

public class DeletePlanCommand : IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}