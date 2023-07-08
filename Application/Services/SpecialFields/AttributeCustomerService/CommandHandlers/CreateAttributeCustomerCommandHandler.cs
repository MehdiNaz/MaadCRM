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
                Value = request.Value,
                FilePath = request.FilePath,
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