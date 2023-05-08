namespace Application.Interfaces.Customers.Foroosh;

public interface IForooshFactorRepository
{
    ValueTask<Result<ICollection<ForooshFactor>>> GetAllForooshFactorsAsync();
    ValueTask<Result<ForooshFactor>> GetForooshFactorByIdAsync(Ulid ForooshFactorId);
    ValueTask<Result<ICollection<FactorInformationResponse>>> ShowAllFactorInformationByForooshFactorIdAsync(Ulid ForooshFactorId);
    ValueTask<Result<ForooshFactor>> ChangeStatusForooshFactorByIdAsync(ChangeStatusForooshFactorCommand request);
    ValueTask<Result<FactorInformationResponse>> CreateForooshFactorAsync(CreateForooshFactorCommand request);
    ValueTask<Result<ForooshFactor>> UpdateForooshFactorAsync(UpdateForooshFactorCommand request);
    ValueTask<Result<ForooshFactor>> DeleteForooshFactorAsync(Ulid id);
}