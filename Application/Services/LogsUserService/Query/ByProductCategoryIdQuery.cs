namespace Application.Services.LogsUserService.Query;

public struct ByProductCategoryIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid ProductCategoryId { get; set; }
}