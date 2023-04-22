namespace Application.Services.BusinessPlansService.Queries;

public struct AllBusinessPlansQuery : IRequest<Result<ICollection<BusinessPlan>>>
{
    public Ulid BusinessId { get; set; }
}