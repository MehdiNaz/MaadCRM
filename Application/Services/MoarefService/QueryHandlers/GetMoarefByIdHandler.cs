namespace Application.Services.MoarefService.QueryHandlers;

public class GetMoarefByIdHandler : IRequestHandler<GetMoarefByIdQuery, Moaref?>
{
    private readonly IMoarefRepository _repository;

    public GetMoarefByIdHandler(IMoarefRepository repository)
    {
        _repository = repository;
    }

    public async Task<Moaref?> Handle(GetMoarefByIdQuery request, CancellationToken cancellationToken)
        => await _repository.GetMoarefByIdAsync(request.MoarefId);
}