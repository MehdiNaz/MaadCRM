namespace Application.Services.CustomerCategoryService.Queries;

public struct AllItemsCustomerCategoryQuery : IRequest<ICollection<CustomerCategory?>>
{
    public string UserId{ get; set; }
}