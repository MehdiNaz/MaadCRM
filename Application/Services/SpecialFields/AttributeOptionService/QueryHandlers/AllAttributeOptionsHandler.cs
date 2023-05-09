namespace Application.Services.SpecialFields.AttributeOptionService.QueryHandlers;

public readonly struct AllAttributeOptionsHandler : IRequestHandler<AllAttributesOptionQuery, Result<ICollection<AttributeOptionResponse>>>
{
    private readonly IAttributeOptionsRepository _repository;

    public AllAttributeOptionsHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<AttributeOptionResponse>>> Handle(AllAttributesOptionQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllAttributeOptionsAsync())
                .Match(result => new Result<ICollection<AttributeOptionResponse>>(result),
                    exception => new Result<ICollection<AttributeOptionResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeOptionResponse>>(new Exception(e.Message));
        }
    }
}