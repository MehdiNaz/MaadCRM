namespace Application.Services.BusinessPlansService.Queries;

public struct AllBusinessPlansQuery : IRequest<ICollection<BusinessPlan?>>
{
    public Ulid BusinessId { get; set; }
}