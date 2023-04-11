namespace Application.Services.ForoshFactorService.Queries;

public struct GetForoshFactorByIdQuery : IRequest<ForoshFactor>
{
    public Ulid ForoshFactorId { get; set; }
}