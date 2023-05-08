namespace Application.Services.Customer.Foroosh.ForooshFactorService.Commands;

public struct ChangeStatusForooshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public Ulid Id { get; set; }
    public Status ForooshFactorStatus { get; set; }
}