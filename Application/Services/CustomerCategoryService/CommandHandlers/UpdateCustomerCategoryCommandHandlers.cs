﻿namespace Application.Services.CustomerCategoryService.CommandHandlers;

public class UpdateCustomerCategoryCommandHandlers : IRequestHandler<UpdateCustomerCategoryCommand, CustomerCategory>
{
    private readonly ICustomerCategoryRepository _repository;

    public UpdateCustomerCategoryCommandHandlers(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerCategory> Handle(UpdateCustomerCategoryCommand request, CancellationToken cancellationToken)
    {
        CustomerCategory customerCategory = new()
        {
            CustomerCategoryId = request.CustomerCategoryId,
            CustomerCategoryName = request.CustomerCategoryName,
            CustomerId = request.CustomerId
        };

        await _repository.UpdateCustomerCategoryAsync(customerCategory);
        return customerCategory;
    }
}
