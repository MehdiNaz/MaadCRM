namespace Application.Services.CustomerCategoryService.Commands;

public struct CreateCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public string CustomerCategoryName { get; set; }
    public ShowTypes IsShown { get; set; }
    public Ulid CategoryId { get; set; }
}