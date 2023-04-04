namespace Application.Services.ForoshFactorService.Commands;

public struct DeleteForoshFactorCommand : IRequest<ForoshFactor>
{
    public Ulid ForoshFactorId { get; set; }
}