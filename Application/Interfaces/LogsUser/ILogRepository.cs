namespace Application.Interfaces.LogsUser;

public interface ILogRepository
{
    ValueTask<Result<ICollection<LogResponse>>> GetAllLogsAsync();
    ValueTask<Result<LogResponse>> GetByLogIdAsync(Ulid logId);
    ValueTask<Result<LogResponse>> GetByPeyGiryIdAsync(Ulid peyGiryId);
    ValueTask<Result<LogResponse>> GetByPeyNoteIdAsync(Ulid noteId);
    ValueTask<Result<LogResponse>> GetByCustomerIdAsync(Ulid customerId);
    ValueTask<Result<LogResponse>> GetByProductIdAsync(Ulid productId);
    ValueTask<Result<LogResponse>> GetByProductCategoryIdAsync(Ulid productCategoryId);
    ValueTask<Result<LogResponse>> GetByForooshIdAsync(Ulid forooshId);
    ValueTask<Result<LogResponse>> CreateLogAsync(CreateLogCommand request);
    ValueTask<Result<LogResponse>> UpdateLogAsync(UpdateLogCommand request);
    ValueTask<Result<LogResponse>> DeleteLogAsync(Ulid id);
}