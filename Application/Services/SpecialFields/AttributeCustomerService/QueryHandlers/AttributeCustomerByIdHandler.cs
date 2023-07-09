namespace Application.Services.SpecialFields.AttributeCustomerService.QueryHandlers;

public readonly struct AttributeCustomerByIdHandler : IRequestHandler<AttributeCustomerByIdQuery, Result<AttributeCustomerResponse>>
{
    private readonly IAttributeCustomerRepository _repository;

    public AttributeCustomerByIdHandler(IAttributeCustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<AttributeCustomerResponse>> Handle(AttributeCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return (await _repository.GetAttributeByIdAsync(request.Id))
                .Match(result => new Result<AttributeCustomerResponse>(result),
                    exception => new Result<AttributeCustomerResponse>(exception));
        }
        catch (Exception e)
        {
            return new Result<AttributeCustomerResponse>(new Exception(e.Message));
        }
    }
}