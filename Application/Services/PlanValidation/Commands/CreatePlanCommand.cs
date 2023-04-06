namespace Application.Services.PlanValidation.Commands;

public abstract class CreatePlanCommand : RequestPlan, IRequest<Plan>
{
}