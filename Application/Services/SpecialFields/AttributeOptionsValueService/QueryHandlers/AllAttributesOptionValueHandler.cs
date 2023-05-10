namespace Application.Services.SpecialFields.AttributeOptionsValueService.QueryHandlers;

public readonly struct AllAttributesOptionValueHandler : IRequestHandler<AllAttributesOptionValueQuery, Result<ICollection<AttributeOptionValueResponse>>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public AllAttributesOptionValueHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<AttributeOptionValueResponse>>> Handle(AllAttributesOptionValueQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllAttributeOptionsValueAsync())
                .Match(result => new Result<ICollection<AttributeOptionValueResponse>>(result),
                    exception => new Result<ICollection<AttributeOptionValueResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeOptionValueResponse>>(new Exception(e.Message));
        }
    }
}