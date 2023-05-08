namespace Application.Services.Customer.Foroosh.ForooshFactorService.Commands;

public struct DeleteForooshFactorCommand : IRequest<Result<ForooshFactor>>
{
    public Ulid Id { get; set; }
}