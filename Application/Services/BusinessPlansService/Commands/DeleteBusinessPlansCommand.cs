namespace Application.Services.BusinessPlansService.Commands;

public struct DeleteBusinessPlansCommand : IRequest<BusinessPlan>
{
    public Ulid BusinessPlansId { get; set; }
}