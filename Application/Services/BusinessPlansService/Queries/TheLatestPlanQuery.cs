namespace Application.Services.BusinessPlansService.Queries;

public class TheLatestPlanQuery : IRequest<BusinessPlans>
{
    public Ulid BusinessPlansId { get; set; }
}