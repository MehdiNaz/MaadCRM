namespace Application.Services.SpecialFields.AttributeService.CommandHandlers;

public readonly struct CreateAttributeCommandHandler : IRequestHandler<CreateAttributeCommand, Result<AttributeResponse>>
{
    private readonly IAttributeRepository _repository;

    public CreateAttributeCommandHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeResponse>> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateAttributeCommand item = new()
            {
                Label = request.Label,
                DisplayOrder = request.DisplayOrder,
                IsRequired = request.IsRequired,
                AttributeInputTypeId = request.AttributeInputTypeId,
                AttributeTypeId = request.AttributeTypeId,
                ValidationMinLength = request.ValidationMinLength,
                ValidationMaxLength = request.ValidationMaxLength,
                ValidationFileAllowExtension = request.ValidationFileAllowExtension,
                ValidationFileMaximumSize = request.ValidationFileMaximumSize,
                DefaultValue = request.DefaultValue,
                IdBusiness = request.IdBusiness,
                IdUserAdded = request.IdUserAdded,
                IdUserUpdated = request.IdUserUpdated,
                Options = request.Options
            };

            return (await _repository.CreateAttributesAsync(item))
                .Match(result => new Result<AttributeResponse>(result),
                    exception => new Result<AttributeResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new Exception(e.Message));
        }
    }
}