namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class DeleteCustomerCategoryHandlers : IRequestHandler<DeleteCustomerCategoryCommand, CustCategory>
{
    private readonly ICustCategoryRepository _repository;

    public DeleteCustomerCategoryHandlers(ICustCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustCategory> Handle(DeleteCustomerCategoryCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCusCustomerAsync(request.CustCategoryId))!;
}