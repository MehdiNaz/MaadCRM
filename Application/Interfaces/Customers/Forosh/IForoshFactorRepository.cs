using Domain.Models.Customers.Foroosh;

namespace Application.Interfaces.Customers.Forosh;

public interface IForoshFactorRepository
{
    ValueTask<ICollection<ForooshFactor?>> GetAllForoshFactorsAsync();
    ValueTask<ForooshFactor?> GetForoshFactorByIdAsync(Ulid foroshFactorId);
    ValueTask<ForooshFactor?> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request);
    ValueTask<ForooshFactor?> CreateForoshFactorAsync(CreateForoshFactorCommand request);
    ValueTask<ForooshFactor?> UpdateForoshFactorAsync(UpdateForoshFactorCommand request);
    ValueTask<ForooshFactor?> DeleteForoshFactorAsync(Ulid id);
}