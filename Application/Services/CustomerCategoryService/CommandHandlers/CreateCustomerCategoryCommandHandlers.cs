namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct CreateCustomerCategoryCommandHandlers : IRequestHandler<CreateCustomerCategoryCommand, Result<CustomerCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public CreateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerCategory>> Handle(CreateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CreateCustomerCategoryCommand customerCategory = new()
            {
                UserId = request.UserId,
                CustomerCategoryName = request.CustomerCategoryName
            };
            return (await _repository.CreateCustomerCategoryAsync(customerCategory)).Match(result => new Result<CustomerCategory>(result), exception => new Result<CustomerCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new Exception(e.Message));
        }
    }
}
