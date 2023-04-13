namespace Application.Services.ForoshFactorService.Commands;

public struct ChangeStatusForoshFactorCommand : IRequest<ForoshFactor?>
{
    public Ulid ForoshFactorId { get; set; }
    public Status ForoshFactorStatus { get; set; }
}