namespace Application.Services.BusinessPlansService.Queries;

public class AllActivePlansQuery : IRequest<ICollection<BusinessPlans>>
{
    public Ulid BusinessId { get; set; }
}