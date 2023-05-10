namespace Application.Services.SpecialFields.AttributeOptionsValueService.CommandHandlers;

public readonly struct UpdateAttributeOptionValueCommandHandler : IRequestHandler<UpdateAttributeOptionValueCommand, Result<AttributeOptionValueResponse>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public UpdateAttributeOptionValueCommandHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionValueResponse>> Handle(UpdateAttributeOptionValueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateAttributeOptionValueCommand item = new()
            {
                Id = request.Id,
                Value = request.Value,
                FilePath = request.FilePath
            };

            return (await _repository.UpdateAttributeOptionsValueAsync(item))
                .Match(result => new Result<AttributeOptionValueResponse>(result),
                    exception => new Result<AttributeOptionValueResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new Exception(e.Message));
        }
    }
}