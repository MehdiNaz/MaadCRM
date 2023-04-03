﻿namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class DeleteCustomerCategoryCommandHandlers : IRequestHandler<DeleteCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public DeleteCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(DeleteCustomerCategoryCommand request, CancellationToken cancellationToken)
        => (await _repository.DeleteCusCustomerAsync(request.CustomerCategoryId))!;
}