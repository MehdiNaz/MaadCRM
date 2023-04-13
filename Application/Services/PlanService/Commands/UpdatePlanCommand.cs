namespace Application.Services.PlanService.Commands;

public struct UpdatePlanCommand : IRequest<Plan>
{
    public required Ulid PlanId { get; set; }
    public required string UserId { get; set; }
    public required string PlanName { get; set; }
    public required uint CountOfUsers { get; set; }
    public required decimal PriceOfUsers { get; set; }
    public required uint CountOfDay { get; set; }
    public required decimal PriceOfDay { get; set; }
}