namespace Application.Services.PlanService.Response;

public struct CreatePlanResponse
{
    public required uint CountOfUsers { get; set; }
    public required uint CountOfDay { get; set; }
    public required decimal FinalPrice { get; set; }
}