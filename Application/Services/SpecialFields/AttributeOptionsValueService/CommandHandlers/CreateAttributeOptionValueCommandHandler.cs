namespace Application.Services.SpecialFields.AttributeOptionsValueService.CommandHandlers;

public readonly struct CreateAttributeOptionValueCommandHandler : IRequestHandler<CreateAttributeOptionValueCommand, Result<AttributeOptionValueResponse>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public CreateAttributeOptionValueCommandHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionValueResponse>> Handle(CreateAttributeOptionValueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateAttributeOptionValueCommand item = new()
            {
                Value = request.Value,
                FilePath = request.FilePath,
                IdAttributeOption = request.IdAttributeOption
            };

            return (await _repository.CreateAttributeOptionsValueAsync(item))
                .Match(result => new Result<AttributeOptionValueResponse>(result),
                    exception => new Result<AttributeOptionValueResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new Exception(e.Message));
        }
    }
}