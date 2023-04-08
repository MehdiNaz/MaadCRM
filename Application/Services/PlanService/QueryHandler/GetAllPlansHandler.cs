namespace Application.Services.PlanService.QueryHandler;

public class GetAllPlansHandler : IRequestHandler<AllPlansQuery, ICollection<Plan?>>
{
    private readonly IPlanRepository _repository;

    public GetAllPlansHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Plan?>> Handle(AllPlansQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllPlansAsync();
}