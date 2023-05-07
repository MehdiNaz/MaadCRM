namespace Application.Services.ForoshFactorService.Commands;

public struct DeleteForoshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public Ulid Id { get; set; }
}