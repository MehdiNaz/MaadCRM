﻿namespace Application.Services.CustomerCategoryService.QueryHandlers;

public readonly struct AllCustomerCategoryHandler : IRequestHandler<AllItemsCustomerCategoryQuery, ICollection<CustomerCategory?>>
{
    private readonly ICustomerCategoryRepository _repository;

    public AllCustomerCategoryHandler(ICustomerCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<CustomerCategory?>> Handle(AllItemsCustomerCategoryQuery request, CancellationToken cancellationToken)
        => await _repository.GetAllCustomerCategoryAsync(request.UserId);
}