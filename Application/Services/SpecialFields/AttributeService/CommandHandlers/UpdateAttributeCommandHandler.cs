namespace Application.Services.SpecialFields.AttributeService.CommandHandlers;

public readonly struct UpdateAttributeCommandHandler : IRequestHandler<UpdateAttributeCommand, Result<AttributeResponse>>
{
    private readonly IAttributeRepository _repository;

    public UpdateAttributeCommandHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeResponse>> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateAttributeCommand item = new()
            {
                Id = request.Id,
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
                IdUserUpdated = request.IdUserUpdated
            };

            return (await _repository.UpdateAttributesAsync(item))
                .Match(result => new Result<AttributeResponse>(result),
                    exception => new Result<AttributeResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new Exception(e.Message));
        }
    }
}