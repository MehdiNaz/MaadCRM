namespace Application.Interfaces;

public interface ISanAtRepository
{
    Task<ICollection<SanAt?>> GetAllSanAtsAsync();
    ValueTask<SanAt?> GetSanAtsByIdAsync(Ulid sanAtId);
    ValueTask<SanAt?> ChangeStatusSanAtsByIdAsync(ChangeStatusSanAtCommand request);
    ValueTask<SanAt?> CreateSanAtsAsync(CreateSanAtCommand request);
    ValueTask<SanAt?> UpdateSanAtsAsync(UpdateSanAtCommand request);
    ValueTask<SanAt?> DeleteSanAtsAsync(DeleteSanAtCommand request);
}