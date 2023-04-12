namespace Application.Services.BusinessPlansService.Queries;

public struct ChangeStatusBusinessPlansQuery : IRequest<BusinessPlan?>
{
    public required Status Status { get; set; }
    public required Ulid BusinessPlansId { get; set; }
}
