namespace Application.Services.PlanService.Queries;

public class PlanByIdQuery : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
}