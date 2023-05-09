namespace Application.Services.SpecialFields.AttributeOptionService.CommandHandlers;

public readonly struct DeleteAttributeOptionCommandHandler : IRequestHandler<DeleteAttributeOptionCommand, Result<AttributeOptionResponse>>
{
    private readonly IAttributeOptionsRepository _repository;

    public DeleteAttributeOptionCommandHandler(IAttributeOptionsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeOptionResponse>> Handle(DeleteAttributeOptionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteAttributeOptionsAsync(request.Id))
                .Match(result => new Result<AttributeOptionResponse>(result),
                    exception => new Result<AttributeOptionResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeOptionResponse>(new Exception(e.Message));
        }
    }
}