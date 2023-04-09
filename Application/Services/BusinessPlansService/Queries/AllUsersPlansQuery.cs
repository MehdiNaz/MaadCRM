namespace Application.Services.BusinessPlansService.Queries;

public class AllBusinessPlansQuery : IRequest<ICollection<BusinessPlans?>>
{
    public Ulid BusinessId { get; set; }
}