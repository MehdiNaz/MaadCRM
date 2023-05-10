namespace Application.Services.SpecialFields.AttributeOptionsValueService.CommandHandlers;

public readonly struct ChangeStatusAttributeOptionValueCommandHandler : IRequestHandler<ChangeStatusAttributeOptionValueCommand, Result<AttributeOptionValueResponse>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public ChangeStatusAttributeOptionValueCommandHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionValueResponse>> Handle(ChangeStatusAttributeOptionValueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.ChangeStatusAttributeOptionsByIdAsync(request))
                .Match(result => new Result<AttributeOptionValueResponse>(result),
                    exception => new Result<AttributeOptionValueResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new Exception(e.Message));
        }
    }
}