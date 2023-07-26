using Domain.Models.Businesses.Plans;

namespace Application.Services.BusinessPlansService.Commands;

public struct CreateBusinessPlansCommand : IRequest<Result<BusinessPlan>>
{
    public Ulid PlanId { get; set; }
    public Ulid BusinessId { get; set; }
    public uint CountOfDay { get; set; }
    public uint CountOfUsers { get; set; }
}
