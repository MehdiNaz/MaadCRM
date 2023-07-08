namespace Application.Services.SpecialFields.AttributeCustomerService.CommandHandlers;

public class DeleteAttributeCustomerCommandHandler : IRequestHandler<DeleteAttributeCustomerCommand, Result<AttributeCustomerResponse>>
{
    private readonly IAttributeCustomerRepository _repository;

    public DeleteAttributeCustomerCommandHandler(IAttributeCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeCustomerResponse>> Handle(DeleteAttributeCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.DeleteAttributesAsync(request.Id))
                .Match(
                    result => new Result<AttributeCustomerResponse>(result),
                    exception => new Result<AttributeCustomerResponse>(exception)
                    );
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new Exception(e.Message));
        }
    }
}