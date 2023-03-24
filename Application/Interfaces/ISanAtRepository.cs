namespace Application.Interfaces;

public interface ISanAtRepository
{
    ValueTask<ICollection<SanAt?>> GetAllSanAtsAsync();
    ValueTask<SanAt?> GetSanAtsByIdAsync(int sanAtId);
    ValueTask<SanAt?> CreateSanAtsAsync(SanAt? toCreate);
    ValueTask<SanAt?> UpdateSanAtsAsync(string updateContent, int sanAtId);
    ValueTask DeleteSanAtsAsync(int sanAtId);
}