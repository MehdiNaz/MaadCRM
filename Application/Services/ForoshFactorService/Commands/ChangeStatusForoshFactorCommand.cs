using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.Commands;

public struct ChangeStatusForoshFactorCommand : IRequest<ForooshFactor?>
{
    public Ulid Id { get; set; }
    public Status ForoshFactorStatus { get; set; }
}