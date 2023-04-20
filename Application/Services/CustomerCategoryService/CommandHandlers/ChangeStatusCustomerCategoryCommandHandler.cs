namespace Application.Services.CustomerCategoryService.CommandHandlers;

public readonly struct ChangeStatusCustomerCategoryCommandHandler : IRequestHandler<ChangeStatusCustomerCategoryCommand, CustomerCategory?>
{
    private readonly ICustomerCategoryRepository _repository;

    public ChangeStatusCustomerCategoryCommandHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory?> Handle(ChangeStatusCustomerCategoryCommand request,
        CancellationToken cancellationToken)
        => await _repository.ChangeStatusCustomerCategoryByIdAsync(request);
}