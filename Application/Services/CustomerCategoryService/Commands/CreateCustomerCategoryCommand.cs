namespace Application.Services.CustomerCategoryService.Commands;

public struct CreateCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public string CustomerCategoryName { get; set; }
}