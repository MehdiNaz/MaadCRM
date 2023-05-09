namespace Application.Services.SpecialFields.AttributeOptionService.CommandHandlers;

public readonly struct UpdateAttributeOptionCommandHandler : IRequestHandler<UpdateAttributeOptionCommand, Result<AttributeOptionResponse>>
{
    private readonly IAttributeOptionsRepository _repository;

    public UpdateAttributeOptionCommandHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionResponse>> Handle(UpdateAttributeOptionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateAttributeOptionCommand item = new()
            {
                Id = request.Id,
                Title = request.Title,
                ColorSquaresRgb = request.ColorSquaresRgb,
                DisplayOrder = request.DisplayOrder,
            };

            return (await _repository.UpdateAttributeOptionsAsync(item))
                .Match(result => new Result<AttributeOptionResponse>(result),
                    exception => new Result<AttributeOptionResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new Exception(e.Message));
        }
    }
}