namespace Application.Services.PlanService.Commands;

public abstract class CreatePlanCommand : RequestPlan, IRequest<Plan>
{
}