namespace Application.Services.Customer.PeyGiryCategoryService.CommandHandler;

public readonly struct CreatePeyGiryCategoryCommandHandler : IRequestHandler<CreatePeyGiryCategoryCommand, Result<PeyGiryCategoryResponse>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public CreatePeyGiryCategoryCommandHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PeyGiryCategoryResponse>> Handle(CreatePeyGiryCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreatePeyGiryCategoryCommand item = new()
            {
                Kind = request.Kind,
                BusinessId = request.BusinessId,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated
            };

            return (await _repository.CreatePeyGiryCategoryAsync(item))
                .Match(result => new Result<PeyGiryCategoryResponse>(result),
                    exception => new Result<PeyGiryCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new Exception(e.Message));
        }
    }
}