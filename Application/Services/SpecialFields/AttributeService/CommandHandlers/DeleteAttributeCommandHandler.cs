namespace Application.Services.SpecialFields.AttributeService.CommandHandlers;

public readonly struct DeleteAttributeCommandHandler : IRequestHandler<DeleteAttributeCommand, Result<AttributeResponse>>
{
    private readonly IAttributeRepository _repository;

    public DeleteAttributeCommandHandler(IAttributeRepository repository)
    {
        _repository = repository;
    }


    public async Task<Result<AttributeResponse>> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteAttributesAsync(request.Id))
                .Match(result => new Result<AttributeResponse>(result),
                    exception => new Result<AttributeResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeResponse>(new Exception(e.Message));
        }
    }
}