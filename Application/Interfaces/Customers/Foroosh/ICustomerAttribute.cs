namespace Application.Interfaces.Customers.Foroosh;

public interface ICustomerAttribute
{
    ValueTask<Result<ICollection<CustomerAttribute>>> GetAllForooshOrdersAsync();
    ValueTask<Result<ForooshOrder>> GetForooshOrderByIdAsync(Ulid forooshOrderId);
    ValueTask<Result<ForooshOrder>> ChangeStatusForooshOrderByIdAsync(ChangeStatusForooshOrderCommand request);
    ValueTask<Result<ForooshOrder>> CreateForooshOrderAsync(CreateForooshOrderCommand request);
    ValueTask<Result<ForooshOrder>> UpdateForooshOrderAsync(UpdateForooshOrderCommand request);
    ValueTask<Result<ForooshOrder>> DeleteForooshOrderAsync(Ulid forooshOrderId);
}