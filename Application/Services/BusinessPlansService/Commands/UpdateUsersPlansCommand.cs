namespace Application.Services.BusinessPlansService.Commands;

public struct UpdateBusinessPlansCommand : IRequest<Result<BusinessPlan>>
{
    public Ulid BusinessPlansId { get; set; }
    public Ulid PlanId { get; set; }
    public Ulid BusinessId { get; set; }
    public uint CountOfDay { get; set; }
    public uint CountOfUsers { get; set; }
}