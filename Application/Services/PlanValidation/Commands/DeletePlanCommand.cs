namespace Application.Services.PlanValidation.Commands;

public struct DeletePlanCommand : IRequest<Plan>
{
    public Ulid PlanId { get; set; }
}