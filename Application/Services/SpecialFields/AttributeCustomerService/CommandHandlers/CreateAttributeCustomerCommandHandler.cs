namespace Application.Services.SpecialFields.AttributeCustomerService.CommandHandlers;

public class CreateAttributeCustomerCommandHandler : IRequestHandler<CreateAttributeCustomerCommand, Result<AttributeCustomerResponse>>
{
    private readonly IAttributeCustomerRepository _repository;

    public CreateAttributeCustomerCommandHandler(IAttributeCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeCustomerResponse>> Handle(CreateAttributeCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateAttributeCustomerCommand item = new()
            {
                ValueString = request.ValueString,
                FilePath = request.FilePath,
                ValueNumber = request.ValueNumber,
                ValueBool = request.ValueBool,
                ValueDate = request.ValueDate,
                IdCustomer = request.IdCustomer,
                IdAttributeOption = request.IdAttributeOption
            };

            return (await _repository.CreateAttributesAsync(item))
                .Match(result => new Result<AttributeCustomerResponse>(result),
                    exception => new Result<AttributeCustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new Exception(e.Message));
        }
    }
}