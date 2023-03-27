namespace Application.Services.MoarefService.QueryHandlers;

public class GetAllMoarefHandler : IRequestHandler<GetAllMoarefQuery, ICollection<Moaref?>>
{
    private readonly IMoarefRepository _repository;

    public GetAllMoarefHandler(IMoarefRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<Moaref?>> Handle(GetAllMoarefQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllMoarefsAsync();
}