namespace Application.Services.Customer.Foroosh.ForooshFactorService.Queries;

public struct AllFactorInformationByForooshFactorIdQuery : IRequest<Result<ICollection<FactorInformationResponse>>>
{
    public Ulid ForooshFactorId { get; set; }
}