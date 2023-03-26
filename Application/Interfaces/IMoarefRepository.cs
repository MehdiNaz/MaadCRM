namespace Application.Interfaces;

public interface IMoarefRepository
{
    Task<ICollection<Moaref?>> GetAllMoarefsAsync();
    ValueTask<Moaref?> GetMoarefByIdAsync(int moarefId);
    ValueTask<Moaref?> CreateMoarefAsync(Moaref? toCreate);
    ValueTask<Moaref?> UpdateMoarefAsync(string updateContent, int moarefId);
    ValueTask DeleteMoarefAsync(int moarefId);
}