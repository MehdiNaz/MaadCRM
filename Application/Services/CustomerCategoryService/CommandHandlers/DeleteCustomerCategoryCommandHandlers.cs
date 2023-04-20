namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct DeleteCustomerCategoryCommandHandlers : IRequestHandler<DeleteCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public DeleteCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(DeleteCustomerCategoryCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCustomerCategoryAsync(request))!;
}