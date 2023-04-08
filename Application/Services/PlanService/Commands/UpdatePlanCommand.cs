namespace Application.Services.PlanService.Commands;

public abstract class UpdatePlanCommand : IRequest<Plan>
{
    public required Ulid Id { get; set; }
    public required uint CountOfUsers { get; set; }
    public required decimal PriceOfUsers { get; set; }
    public required uint CountOfDay { get; set; }
    public required decimal PriceOfDay { get; set; }
}