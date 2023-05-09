namespace Application.Services.SpecialFields.AttributeOptionService.CommandHandlers;

public readonly struct ChangeStatusAttributeOptionCommandHandler : IRequestHandler<ChangeStatusAttributeOptionCommand, Result<AttributeOptionResponse>>
{
    private readonly IAttributeOptionsRepository _repository;

    public ChangeStatusAttributeOptionCommandHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionResponse>> Handle(ChangeStatusAttributeOptionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusAttributeIdAsync(request))
                .Match(result => new Result<AttributeOptionResponse>(result),
                    exception => new Result<AttributeOptionResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new Exception(e.Message));
        }
    }
}