namespace Application.Interfaces.Customers.Forosh;

public interface IForoshFactorRepository
{
    ValueTask<ICollection<ForoshFactor?>> GetAllForoshFactorsAsync();
    ValueTask<ForoshFactor?> GetForoshFactorByIdAsync(Ulid foroshFactorId);
    ValueTask<ForoshFactor?> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request);
    ValueTask<ForoshFactor?> CreateForoshFactorAsync(CreateForoshFactorCommand request);
    ValueTask<ForoshFactor?> UpdateForoshFactorAsync(UpdateForoshFactorCommand request);
    ValueTask<ForoshFactor?> DeleteForoshFactorAsync(DeleteForoshFactorCommand request);
}