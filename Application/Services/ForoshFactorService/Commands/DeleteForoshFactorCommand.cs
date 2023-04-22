using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.Commands;

public struct DeleteForoshFactorCommand : IRequest<ForooshFactor>
{
    public Ulid Id { get; set; }
}