namespace Application.Services.SpecialFields.AttributeOptionService.QueryHandlers;

public readonly struct AttributeOptionByIdHandler : IRequestHandler<AttributeOptionByIdQuery, Result<AttributeOptionResponse>>
{
    private readonly IAttributeOptionsRepository _repository;

    public AttributeOptionByIdHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionResponse>> Handle(AttributeOptionByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAttributeOptionsByIdAsync(request.Id))
                .Match(result => new Result<AttributeOptionResponse>(result),
                    exception => new Result<AttributeOptionResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new Exception(e.Message));
        }
    }
}