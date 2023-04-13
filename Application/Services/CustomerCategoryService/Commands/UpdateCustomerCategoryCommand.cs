namespace Application.Services.CustomerCategoryService.Commands;

public struct UpdateCustomerCategoryCommand:IRequest<CustomerCategory>
{
    public string UserId { get; set; }
    public Ulid CustomerCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
}