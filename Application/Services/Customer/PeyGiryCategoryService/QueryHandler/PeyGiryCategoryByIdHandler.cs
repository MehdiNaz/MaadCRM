namespace Application.Services.Customer.PeyGiryCategoryService.QueryHandler;

public readonly struct PeyGiryCategoryByIdHandler : IRequestHandler<PeyGiryCategoryByIdQuery, Result<PeyGiryCategoryResponse>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public PeyGiryCategoryByIdHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PeyGiryCategoryResponse>> Handle(PeyGiryCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetPeyGiryCategoryByIdAsync(request.PeyGiryCategoryId))
                .Match(result => new Result<PeyGiryCategoryResponse>(result),
                    exception => new Result<PeyGiryCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new Exception(e.Message));
        }
    }
}