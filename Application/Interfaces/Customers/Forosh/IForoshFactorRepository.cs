namespace Application.Interfaces.Customers.Forosh;

public interface IForoshFactorRepository
{
    ValueTask<Result<ICollection<ForooshFactor>>> GetAllForoshFactorsAsync();
    ValueTask<Result<ForooshFactor>> GetForoshFactorByIdAsync(Ulid foroshFactorId);
    ValueTask<Result<ForooshFactor>> ChangeStatusForoshFactorByIdAsync(ChangeStatusForoshFactorCommand request);
    ValueTask<Result<ForooshFactor>> CreateForoshFactorAsync(CreateForoshFactorCommand request);
    ValueTask<Result<ForooshFactor>> UpdateForoshFactorAsync(UpdateForoshFactorCommand request);
    ValueTask<Result<ForooshFactor>> DeleteForoshFactorAsync(Ulid id);
}