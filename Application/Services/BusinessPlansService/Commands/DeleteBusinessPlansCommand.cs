namespace Application.Services.BusinessPlansService.Commands;

public struct DeleteBusinessPlansCommand : IRequest<BusinessPlans>
{
    public Ulid BusinessPlansId { get; set; }
}