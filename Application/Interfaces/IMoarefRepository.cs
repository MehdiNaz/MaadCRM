namespace Application.Interfaces;

public interface IMoarefRepository
{
    Task<ICollection<Moaref?>> GetAllMoarefsAsync();
    ValueTask<Moaref?> GetMoarefByIdAsync(Ulid moarefId);
    ValueTask<Moaref?> CreateMoarefAsync(Moaref? entity);
    ValueTask<Moaref?> UpdateMoarefAsync(Moaref entity, Ulid moarefId);
    ValueTask<Moaref?> DeleteMoarefAsync(Ulid moarefId);
}