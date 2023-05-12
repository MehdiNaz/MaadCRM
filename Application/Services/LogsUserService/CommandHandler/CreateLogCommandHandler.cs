namespace Application.Services.LogsUserService.CommandHandler;

public readonly struct CreateLogCommandHandler : IRequestHandler<CreateLogCommand, Result<LogResponse>>
{
    private readonly ILogRepository _repository;

    public CreateLogCommandHandler(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<LogResponse>> Handle(CreateLogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateLogCommand item = new()
            {
                PeyGiryId = request.PeyGiryId,
                NoteId = request.NoteId,
                FeedBackId = request.FeedBackId,
                CustomerId = request.CustomerId,
                ProductId = request.ProductId,
                ProductCategoryId = request.ProductCategoryId,
                ForooshId = request.ForooshId,
                UserId = request.UserId,
                IpAddress = request.IpAddress,
                UserAgent = request.UserAgent,
                Description = request.Description,
                Type = request.Type
            };

            return (await _repository.InsertAsync(item))
                .Match(result => new Result<LogResponse>(result),
                    exception => new Result<LogResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<LogResponse>(new Exception(e.Message));
        }
    }
}