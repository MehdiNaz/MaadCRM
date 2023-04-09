namespace Application.Services.BusinessPlansService.Queries;

public struct AllActivePlansQuery : IRequest<ICollection<BusinessPlans>>
{
    public Ulid BusinessId { get; set; }
}