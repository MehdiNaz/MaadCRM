namespace Application.Services.SpecialFields.AttributeCustomerService.CommandHandlers;

public class ChangeStatusAttributeCustomerCommandHandler : IRequestHandler<ChangeStatusAttributeCustomerCommand, Result<AttributeCustomerResponse>>
{
    private readonly IAttributeCustomerRepository _repository;

    public ChangeStatusAttributeCustomerCommandHandler(IAttributeCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeCustomerResponse>> Handle(ChangeStatusAttributeCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ChangeStatusAttributeCustomerCommand item = new()
            {
                Id = request.Id,
                Status = request.Status
            };

            return (await _repository.ChangeStatusAttributeIdAsync(item))
                .Match(result => new Result<AttributeCustomerResponse>(result),
                    exception => new Result<AttributeCustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new Exception(e.Message));
        }
    }
}