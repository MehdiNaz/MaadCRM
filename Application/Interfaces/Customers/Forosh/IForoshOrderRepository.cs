namespace Application.Interfaces.Customers.Forosh;

public interface IForoshOrderRepository
{
    ValueTask<ICollection<ForooshOrder?>> GetAllForoshOrdersAsync();
    ValueTask<ForooshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId);
    ValueTask<ForooshOrder?> ChangeStatusForoshOrderByIdAsync(ChangeStatusForoshOrderCommand request);
    ValueTask<ForooshOrder?> CreateForoshOrderAsync(CreateForoshOrderCommand request);
    ValueTask<ForooshOrder?> UpdateForoshOrderAsync(UpdateForoshOrderCommand request);
    ValueTask<ForooshOrder?> DeleteForoshOrderAsync(Ulid id);
}