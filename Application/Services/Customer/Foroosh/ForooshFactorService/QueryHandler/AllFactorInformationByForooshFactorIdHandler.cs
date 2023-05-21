using Application.Responses.Customer.Foroosh;

namespace Application.Services.Customer.Foroosh.ForooshFactorService.QueryHandler;

public readonly struct AllFactorInformationByForooshFactorIdHandler : IRequestHandler<AllFactorInformationByForooshFactorIdQuery, Result<ICollection<FactorInformationResponse>>>
{
    private readonly IForooshFactorRepository _repository;

    public AllFactorInformationByForooshFactorIdHandler(IForooshFactorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<FactorInformationResponse>>> Handle(AllFactorInformationByForooshFactorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ShowAllFactorInformationByForooshFactorIdAsync(request.ForooshFactorId))
                .Match(result => new Result<ICollection<FactorInformationResponse>>(result),
                    exception => new Result<ICollection<FactorInformationResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<FactorInformationResponse>>(new Exception(e.Message));
        }
    }
}