namespace Application.Interfaces;

public interface ISanAtRepository
{
    Task<ICollection<SanAt?>> GetAllSanAtsAsync();
    ValueTask<SanAt?> GetSanAtsByIdAsync(Ulid sanAtId);
    ValueTask<SanAt?> ChangeStatusSanAtsByIdAsync(Status status, Ulid sanAtId);
    ValueTask<SanAt?> CreateSanAtsAsync(SanAt? entity);
    ValueTask<SanAt?> UpdateSanAtsAsync(SanAt entity, Ulid sanAtId);
    ValueTask<SanAt?> DeleteSanAtsAsync(Ulid sanAtId);
}