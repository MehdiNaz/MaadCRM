namespace Application.Services.SpecialFields.AttributeCustomerService.QueryHandlers;

public readonly struct AllAttributesCustomerHandler : IRequestHandler<AllAttributesCustomerQuery, Result<ICollection<AttributeCustomerResponse>>>
{
    private readonly IAttributeCustomerRepository _repositoryAttribute;
    private readonly IBusinessRepository _repositoryBusiness;
    

    public AllAttributesCustomerHandler(IAttributeCustomerRepository repository, IBusinessRepository repositoryBusiness)
    {
        _repositoryAttribute = repository;
        _repositoryBusiness = repositoryBusiness;
    }

    public async Task<Result<ICollection<AttributeCustomerResponse>>> Handle(AllAttributesCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var idBusiness = (await _repositoryBusiness.GetBusinessByUserIdAsync(request.IdUser))
                .Match( business => business.Id,  exception => Ulid.Empty );
            
            return (await _repositoryAttribute.GetAllAttributesAsync(request.IdCustomer))
                .Match(result => new Result<ICollection<AttributeCustomerResponse>>(result),
                    exception => new Result<ICollection<AttributeCustomerResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeCustomerResponse>>(new Exception(e.Message));
        }
    }
}