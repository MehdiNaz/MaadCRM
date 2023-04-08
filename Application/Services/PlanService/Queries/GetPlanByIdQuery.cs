namespace Application.Services.PlanService.Queries;

public class GetPlanByIdQuery : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
}