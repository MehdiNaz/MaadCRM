namespace Application.Services.CustomerCategoryService.Commands;

public struct UpdateCustomerCategoryCommand:IRequest<CustomerCategory>
{
    public Ulid CustomerCategoryId { get; set; }
    public string CustomerCategoryName { get; set; }
    public Ulid CategoryId { get; set; }
}