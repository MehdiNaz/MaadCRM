namespace Application.Services.Customer.PeyGiryCategoryService.CommandHandler;

public readonly struct DeletePeyGiryCategoryCommandHandler : IRequestHandler<DeletePeyGiryCategoryCommand, Result<PeyGiryCategoryResponse>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public DeletePeyGiryCategoryCommandHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PeyGiryCategoryResponse>> Handle(DeletePeyGiryCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeletePeyGiryCategoryAsync(request.Id))
                .Match(result => new Result<PeyGiryCategoryResponse>(result),
                    exception => new Result<PeyGiryCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new Exception(e.Message));
        }
    }
}