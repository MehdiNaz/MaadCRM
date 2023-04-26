namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct UpdateCustomerCategoryCommandHandlers : IRequestHandler<UpdateCustomerCategoryCommand, Result<CustomerCategory>>
{
    private readonly ICustomerCategoryRepository _repository;

    public UpdateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<CustomerCategory>> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            UpdateCustomerCategoryCommand customerCategory = new()
            {
                Id = request.Id,
                CustomerCategoryName = request.CustomerCategoryName,
                UserId = request.UserId
            };
            return (await _repository.UpdateCustomerCategoryAsync(customerCategory))
                .Match(result => new Result<CustomerCategory>(result),
                    exception => new Result<CustomerCategory>(exception));
        }
        catch (Exception e)
        {
            return new Result<CustomerCategory>(new Exception(e.Message));
        }
    }
}
