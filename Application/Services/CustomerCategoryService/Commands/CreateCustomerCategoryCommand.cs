namespace Application.Services.CustomerCategoryService.Commands;

public struct CreateCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public string UserId { get; set; }
    public string CustomerCategoryName { get; set; }
}