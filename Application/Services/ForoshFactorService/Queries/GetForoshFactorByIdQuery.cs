namespace Application.Services.ForoshFactorService.Queries;

public struct GetForoshFactorByIdQuery : IRequest<Result<ForooshFactor>>
{
    public Ulid ForoshFactorId { get; set; }
}