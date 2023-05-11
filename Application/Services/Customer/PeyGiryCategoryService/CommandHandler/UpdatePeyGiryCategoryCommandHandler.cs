namespace Application.Services.Customer.PeyGiryCategoryService.CommandHandler;

public readonly struct UpdatePeyGiryCategoryCommandHandler : IRequestHandler<UpdatePeyGiryCategoryCommand, Result<PeyGiryCategoryResponse>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public UpdatePeyGiryCategoryCommandHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PeyGiryCategoryResponse>> Handle(UpdatePeyGiryCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdatePeyGiryCategoryCommand item = new()
            {
                Id = request.Id,
                Kind = request.Kind,
                BusinessId = request.BusinessId,
                IdUserUpdated = request.IdUserUpdated
            };

            return (await _repository.UpdatePeyGiryCategoryAsync(item))
                .Match(result => new Result<PeyGiryCategoryResponse>(result),
                    exception => new Result<PeyGiryCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new Exception(e.Message));
        }
    }
}