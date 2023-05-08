using Application.Services.Customer.Foroosh.ForooshOrderService.Commands;

namespace Application.Interfaces.Customers.Foroosh;

public interface IForooshOrderRepository
{
    ValueTask<ICollection<ForooshOrder?>> GetAllForooshOrdersAsync();
    ValueTask<ForooshOrder?> GetForooshOrderByIdAsync(Ulid ForooshOrderId);
    ValueTask<ForooshOrder?> ChangeStatusForooshOrderByIdAsync(ChangeStatusForooshOrderCommand request);
    ValueTask<ForooshOrder?> CreateForooshOrderAsync(CreateForooshOrderCommand request);
    ValueTask<ForooshOrder?> UpdateForooshOrderAsync(UpdateForooshOrderCommand request);
    ValueTask<ForooshOrder?> DeleteForooshOrderAsync(Ulid id);
}