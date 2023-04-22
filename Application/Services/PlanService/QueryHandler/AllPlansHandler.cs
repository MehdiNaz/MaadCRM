using Domain.Models.Businesses.Plans;

namespace Application.Services.PlanService.QueryHandler;

public readonly struct AllPlansHandler : IRequestHandler<AllPlansQuery, ICollection<Plan?>>
{
    private readonly IPlanRepository _repository;

    public AllPlansHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Plan?>> Handle(AllPlansQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllPlansAsync();
}