namespace Application.Services.PlanValidation.Queries;

public class GetPlanByIdQuery : IRequest<Plan?>
{
    public Ulid PlanId { get; set; }
}