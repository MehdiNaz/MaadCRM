namespace Application.Interfaces.Customers.Forosh;

public interface IForoshOrderRepository
{
    ValueTask<ICollection<ForoshOrder?>> GetAllForoshOrdersAsync();
    ValueTask<ForoshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId);
    ValueTask<ForoshOrder?> ChangeStatusForoshOrderByIdAsync(Status status, Ulid foroshOrderId);
    ValueTask<ForoshOrder?> CreateForoshOrderAsync(ForoshOrder? entity);
    ValueTask<ForoshOrder?> UpdateForoshOrderAsync(ForoshOrder entity, Ulid foroshOrderId);
    ValueTask<ForoshOrder?> DeleteForoshOrderAsync(Ulid foroshOrderId);
}