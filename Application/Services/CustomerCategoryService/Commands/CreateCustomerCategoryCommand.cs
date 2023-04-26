namespace Application.Services.CustomerCategoryService.Commands;

public struct CreateCustomerCategoryCommand : IRequest<Result<CustomerCategory>>
{
    public string UserId { get; set; }
    public string CustomerCategoryName { get; set; }
}