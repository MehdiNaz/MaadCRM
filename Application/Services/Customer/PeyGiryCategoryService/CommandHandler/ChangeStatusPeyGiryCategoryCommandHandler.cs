namespace Application.Services.Customer.PeyGiryCategoryService.CommandHandler;

public readonly struct ChangeStatusPeyGiryCategoryCommandHandler : IRequestHandler<ChangeStatusPeyGiryCategoryCommand, Result<PeyGiryCategoryResponse>>
{
    private readonly IPeyGiryCategoryRepository _repository;

    public ChangeStatusPeyGiryCategoryCommandHandler(IPeyGiryCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<PeyGiryCategoryResponse>> Handle(ChangeStatusPeyGiryCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusPeyGiryCategoryByIdAsync(request))
                .Match(result => new Result<PeyGiryCategoryResponse>(result),
                    exception => new Result<PeyGiryCategoryResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<PeyGiryCategoryResponse>(new Exception(e.Message));
        }
    }
}