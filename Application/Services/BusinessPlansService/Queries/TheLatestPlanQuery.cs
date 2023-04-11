namespace Application.Services.BusinessPlansService.Queries;

public struct TheLatestPlanQuery : IRequest<BusinessPlan>
{
    public Ulid BusinessId { get; set; }
}