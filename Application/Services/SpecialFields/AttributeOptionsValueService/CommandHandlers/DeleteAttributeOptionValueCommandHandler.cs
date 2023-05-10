namespace Application.Services.SpecialFields.AttributeOptionsValueService.CommandHandlers;

public readonly struct DeleteAttributeOptionValueCommandHandler: IRequestHandler<DeleteAttributeOptionValueCommand, Result<AttributeOptionValueResponse>>
{
    private readonly IAttributeOptionsValueRepository _repository;

    public DeleteAttributeOptionValueCommandHandler(IAttributeOptionsValueRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionValueResponse>> Handle(DeleteAttributeOptionValueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteAttributeOptionsValueAsync(request.Id))
                .Match(result => new Result<AttributeOptionValueResponse>(result),
                    exception => new Result<AttributeOptionValueResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionValueResponse>(new Exception(e.Message));
        }
    }
}