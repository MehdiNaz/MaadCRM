namespace Application.Services.BusinessPlansService.Queries;

public struct TheLatestPlanQuery : IRequest<BusinessPlans>
{
    public Ulid BusinessId { get; set; }
}