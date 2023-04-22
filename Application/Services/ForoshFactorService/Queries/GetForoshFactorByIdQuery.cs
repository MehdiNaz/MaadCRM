using Domain.Models.Customers.Foroosh;

namespace Application.Services.ForoshFactorService.Queries;

public struct GetForoshFactorByIdQuery : IRequest<ForooshFactor>
{
    public Ulid ForoshFactorId { get; set; }
}