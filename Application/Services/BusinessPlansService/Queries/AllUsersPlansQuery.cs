namespace Application.Services.BusinessPlansService.Queries;

public struct AllBusinessPlansQuery : IRequest<ICollection<BusinessPlans?>>
{
    public Ulid BusinessId { get; set; }
}