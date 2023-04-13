namespace Application.Interfaces.Customers.Forosh;

public interface IForoshFactorRepository
{
    ValueTask<ICollection<ForoshFactor?>> GetAllForoshFactorsAsync();
    ValueTask<ForoshFactor?> GetForoshFactorByIdAsync(Ulid foroshFactorId);
    ValueTask<ForoshFactor?> ChangeStatusForoshFactorByIdAsync(Status status, Ulid foroshFactorId);
    ValueTask<ForoshFactor?> CreateForoshFactorAsync(ForoshFactor? entity);
    ValueTask<ForoshFactor?> UpdateForoshFactorAsync(ForoshFactor entity, Ulid foroshFactorId);
    ValueTask<ForoshFactor?> DeleteForoshFactorAsync(Ulid foroshFactorId);
}