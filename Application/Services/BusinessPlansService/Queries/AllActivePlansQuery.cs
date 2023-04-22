namespace Application.Services.BusinessPlansService.Queries;

public struct AllActivePlansQuery : IRequest<Result<ICollection<BusinessPlan>>>
{
    public Ulid BusinessId { get; set; }
}