namespace Application.Services.BusinessPlansService.Commands;

public struct ChangeStatusBusinessPlansQuery : IRequest<Result<BusinessPlan>>
{
    public required Status Status { get; set; }
    public required Ulid BusinessPlansId { get; set; }
}
