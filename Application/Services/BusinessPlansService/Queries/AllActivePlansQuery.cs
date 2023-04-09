namespace Application.Services.BusinessPlansService.Queries;

public class AllActivePlansQuery : IRequest<ICollection<BusinessPlans>>
{
    public Ulid BusinessPlansId { get; set; }
}