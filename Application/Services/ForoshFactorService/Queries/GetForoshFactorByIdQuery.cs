namespace Application.Services.ForoshFactorService.Queries;

public class GetForoshFactorByIdQuery : IRequest<ForoshFactor>
{
    public Ulid ForoshFactorId { get; set; }
}