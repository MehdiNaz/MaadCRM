namespace Application.Interfaces.Customers.Forosh;

public interface IForoshOrderRepository
{
    ValueTask<ICollection<ForoshOrder?>> GetAllForoshOrdersAsync();
    ValueTask<ForoshOrder?> GetForoshOrderByIdAsync(Ulid foroshOrderId);
    ValueTask<ForoshOrder?> ChangeStatusForoshOrderByIdAsync(ChangeStatusForoshOrderCommand request);
    ValueTask<ForoshOrder?> CreateForoshOrderAsync(CreateForoshOrderCommand request);
    ValueTask<ForoshOrder?> UpdateForoshOrderAsync(UpdateForoshOrderCommand request);
    ValueTask<ForoshOrder?> DeleteForoshOrderAsync(DeleteForoshOrderCommand request);
}