namespace Application.Services.CustomerCategoryService.Queries;

public struct AllItemsCustomerCategoryQuery : IRequest<Result<ICollection<CustomerCategory>>>
{
    public string UserId{ get; set; }
}