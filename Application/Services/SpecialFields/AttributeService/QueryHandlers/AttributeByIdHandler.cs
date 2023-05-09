namespace Application.Services.SpecialFields.AttributeService.QueryHandlers;

public readonly struct AttributeByIdHandler : IRequestHandler<AttributeByIdQuery, Result<AttributeResponse>>
{
    private readonly IAttributeRepository _repository;

    public AttributeByIdHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeResponse>> Handle(AttributeByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAttributesByIdAsync(request.Id))
                .Match(result => new Result<AttributeResponse>(result),
                    exception => new Result<AttributeResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new Exception(e.Message));
        }
    }
}