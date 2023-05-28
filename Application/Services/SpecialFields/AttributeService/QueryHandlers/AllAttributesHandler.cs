namespace Application.Services.SpecialFields.AttributeService.QueryHandlers;

public readonly struct AllAttributesHandler : IRequestHandler<AllAttributeQuery, Result<ICollection<AttributeResponse>>>
{
    private readonly IAttributeRepository _repositoryAttribute;
    private readonly IBusinessRepository _repositoryBusiness;
    

    public AllAttributesHandler(IAttributeRepository repository, IBusinessRepository repositoryBusiness)
    {
        _repositoryAttribute = repository;
        _repositoryBusiness = repositoryBusiness;
    }

    public async Task<Result<ICollection<AttributeResponse>>> Handle(AllAttributeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var idBusiness = (await _repositoryBusiness.GetBusinessByUserIdAsync(request.IdUser))
                .Match( business => business.Id,  exception => Ulid.Empty );
            
            return (await _repositoryAttribute.GetAllAttributesAsync(request.Type,idBusiness))
                .Match(result => new Result<ICollection<AttributeResponse>>(result),
                    exception => new Result<ICollection<AttributeResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeResponse>>(new Exception(e.Message));
        }
    }
}