namespace Application.Services.CustomerCategoryService.Commands;

public struct DeleteCustomerCategoryCommand : IRequest<CustomerCategory>
{
    public Ulid Id { get; set; }
    public string UserId { get; set; }
}