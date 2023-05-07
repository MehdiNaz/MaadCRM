namespace Application.Services.Customer.Foroosh.ForooshFactorService.Queries;

public struct ForooshFactorByIdQuery : IRequest<Result<ForooshFactor>>
{
    public Ulid ForooshFactorId { get; set; }
}