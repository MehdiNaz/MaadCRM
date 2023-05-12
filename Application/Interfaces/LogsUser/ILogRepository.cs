namespace Application.Interfaces.LogsUser;

public interface ILogRepository
{
    ValueTask<Result<ICollection<LogResponse>>> GetAllLogsAsync();
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUserIdAsync(string userId);

    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertPeyGiryAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdatePeyGiryAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeletePeyGiryAsync(LogTypes request);

    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertNoteAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateNoteAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteNoteAsync(LogTypes request);  
    
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertFeedBackAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateFeedBackAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteFeedBackAsync(LogTypes request);

    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertCustomerAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateCustomerAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteCustomerAsync(LogTypes request);
    
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertProductCategoryAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateProductCategoryAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteProductCategoryAsync(LogTypes request);

    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertForooshAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateForooshAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteForooshAsync(LogTypes request);
    
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByInsertProductAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByUpdateProductAsync(LogTypes request);
    ValueTask<Result<ICollection<LogResponse>>> GetLogsByDeleteProductAsync(LogTypes request);
    
    ValueTask<Result<LogResponse>> GetByLogIdAsync(Ulid logId);
    ValueTask<Result<LogResponse>> GetByPeyGiryIdAsync(Ulid peyGiryId);
    ValueTask<Result<LogResponse>> GetByNoteIdAsync(Ulid noteId);
    ValueTask<Result<LogResponse>> GetByCustomerIdAsync(Ulid customerId);
    ValueTask<Result<LogResponse>> GetByProductIdAsync(Ulid productId);
    ValueTask<Result<LogResponse>> GetByProductCategoryIdAsync(Ulid productCategoryId);
    ValueTask<Result<LogResponse>> GetByForooshIdAsync(Ulid forooshId);
    ValueTask<Result<LogResponse>> InsertAsync(CreateLogCommand request);
    ValueTask<Result<LogResponse>> DeleteLogAsync(Ulid id);
}