namespace Application.Services.Customer.PeyGiryCategoryService.QueryHandler;

public readonly struct AllPeyGiryCategoriesHandler : IRequestHandler<AllPeyGiryCategoriesQuery, Result<ICollection<PeyGiryCategoryResponse>>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public AllPeyGiryCategoriesHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<PeyGiryCategoryResponse>>> Handle(AllPeyGiryCategoriesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllPeyGiryCategoriesAsync(request.BusinessId))
                .Match(result => new Result<ICollection<PeyGiryCategoryResponse>>(result),
                    exception => new Result<ICollection<PeyGiryCategoryResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<PeyGiryCategoryResponse>>(new Exception(e.Message));
        }
    }
}