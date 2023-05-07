namespace Application.Services.ForoshFactorService.Commands;

public struct ChangeStatusForoshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public Ulid Id { get; set; }
    public Status ForoshFactorStatus { get; set; }
}