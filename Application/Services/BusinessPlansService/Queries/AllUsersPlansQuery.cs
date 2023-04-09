namespace Application.Services.BusinessPlansService.Queries;

public class AllBusinessPlansQuery : IRequest<ICollection<BusinessPlans?>>
{
    public Ulid BusinessPlansId { get; set; }
}