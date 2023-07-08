namespace Application.Services.SpecialFields.AttributeCustomerService.CommandHandlers;

public class UpdateAttributeCustomerCommandHandler : IRequestHandler<UpdateAttributeCustomerCommand, Result<AttributeCustomerResponse>>
{
    private readonly IAttributeCustomerRepository _repository;

    public UpdateAttributeCustomerCommandHandler(IAttributeCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeCustomerResponse>> Handle(UpdateAttributeCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateAttributeCustomerCommand item = new()
            {
                Id = request.Id,
                Value = request.Value,
                FilePath = request.FilePath
            };

            return (await _repository.UpdateAttributesAsync(item))
                .Match(result => new Result<AttributeCustomerResponse>(result),
                    exception => new Result<AttributeCustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new Exception(e.Message));
        }
    }
}