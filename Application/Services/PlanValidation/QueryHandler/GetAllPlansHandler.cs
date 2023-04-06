namespace Application.Services.PlanValidation.QueryHandler;

public class GetAllPlansHandler : IRequestHandler<GetAllPlansQuery, ICollection<Plan?>>
{
    private readonly IPlanRepository _repository;

    public GetAllPlansHandler(IPlanRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Plan?>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllPlansAsync();
}