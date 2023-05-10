namespace Application.Services.SpecialFields.AttributeOptionsValueService.QueryHandlers;

public readonly struct AttributeOptionValueByIdHandler : IRequestHandler<AttributeOptionValueByIdQuery, Result<AttributeOptionValueResponse>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public AttributeOptionValueByIdHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionValueResponse>> Handle(AttributeOptionValueByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAttributeOptionsValueByIdAsync(request.Id))
                .Match(result => new Result<AttributeOptionValueResponse>(result),
                    exception => new Result<AttributeOptionValueResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new Exception(e.Message));
        }
    }
}