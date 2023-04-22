namespace Application.Services.BusinessPlansService.Commands;

public struct DeleteBusinessPlansCommand : IRequest<Result<BusinessPlan>>
{
    public Ulid BusinessPlansId { get; set; }
}