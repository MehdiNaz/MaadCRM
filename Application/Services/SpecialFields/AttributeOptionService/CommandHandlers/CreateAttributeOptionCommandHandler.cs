namespace Application.Services.SpecialFields.AttributeOptionService.CommandHandlers;

public readonly struct CreateAttributeOptionCommandHandler : IRequestHandler<CreateAttributeOptionCommand, Result<AttributeOptionResponse>>
{
    private readonly IAttributeOptionsRepository _repository;

    public CreateAttributeOptionCommandHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionResponse>> Handle(CreateAttributeOptionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateAttributeOptionCommand item = new()
            {
                Title = request.Title,
                ColorSquaresRgb = request.ColorSquaresRgb,
                DisplayOrder = request.DisplayOrder,
                IdAttribute = request.IdAttribute
            };

            return (await _repository.CreateAttributeOptionsAsync(item))
                .Match(result => new Result<AttributeOptionResponse>(result),
                    exception => new Result<AttributeOptionResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new Exception(e.Message));
        }
    }
}