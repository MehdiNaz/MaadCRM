namespace Application.Services.SpecialFields.AttributeService.CommandHandlers;

public readonly struct ChangeStatusAttributeCommandHandler : IRequestHandler<ChangeStatusAttributeCommand, Result<AttributeResponse>>
{
    private readonly IAttributeRepository _repository;

    public ChangeStatusAttributeCommandHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeResponse>> Handle(ChangeStatusAttributeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusAttributeIdAsync(request))
                .Match(result => new Result<AttributeResponse>(result),
                    exception => new Result<AttributeResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new Exception(e.Message));
        }
    }
}