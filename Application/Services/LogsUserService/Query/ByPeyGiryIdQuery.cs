namespace Application.Services.LogsUserService.Query;

public struct ByPeyGiryIdQuery : IRequest<Result<LogResponse>>
{
    public Ulid PeyGiryId { get; set; }
}