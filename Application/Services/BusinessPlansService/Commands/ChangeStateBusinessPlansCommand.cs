namespace Application.Services.BusinessPlansService.Commands;

public struct ChangeStateBusinessPlansCommand : IRequest<BusinessPlan?>
{
    public Ulid BusinessPlansId { get; set; }
    public Status Status { get; set; }
}