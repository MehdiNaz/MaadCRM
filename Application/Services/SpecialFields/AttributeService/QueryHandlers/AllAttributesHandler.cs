namespace Application.Services.SpecialFields.AttributeService.QueryHandlers;

public readonly struct AllAttributesHandler : IRequestHandler<AllAttributeQuery, Result<ICollection<AttributeResponse>>>
{
    private readonly IAttributeRepository _repository;

    public AllAttributesHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ICollection<AttributeResponse>>> Handle(AllAttributeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAllAttributesAsync())
                .Match(result => new Result<ICollection<AttributeResponse>>(result),
                    exception => new Result<ICollection<AttributeResponse>>(exception));
        }
        catch (Exception e)
        {
            return new Result<ICollection<AttributeResponse>>(new Exception(e.Message));
        }
    }
}