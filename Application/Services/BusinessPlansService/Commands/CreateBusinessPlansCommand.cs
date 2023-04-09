namespace Application.Services.BusinessPlansService.Commands;

public class CreateBusinessPlansCommand : IRequest<BusinessPlans>
{
    public Ulid PlanId { get; set; }
    public Ulid BusinessId { get; set; }
    public uint CountOfDay { get; set; }
    public uint CountOfUsers { get; set; }
}
