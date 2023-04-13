namespace Application.Services.PlanService.Commands;

public struct CreatePlanCommand : IRequest<Plan>
{
    public string UserId { get; set; }
    public string PlanName { get; set; }
    public uint CountOfUsers { get; set; }
    public decimal PriceOfUsers { get; set; }
    public uint CountOfDay { get; set; }
    public decimal PriceOfDay { get; set; }
}