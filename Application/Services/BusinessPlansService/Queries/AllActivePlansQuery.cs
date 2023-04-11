namespace Application.Services.BusinessPlansService.Queries;

public struct AllActivePlansQuery : IRequest<ICollection<BusinessPlan>>
{
    public Ulid BusinessId { get; set; }
}