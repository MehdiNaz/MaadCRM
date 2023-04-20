namespace Application.Services.CustomerCategoryService.Commands;

public struct UpdateCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public Ulid Id { get; set; }
    public string CustomerCategoryName { get; set; }
    public string UserId { get; set; }
}